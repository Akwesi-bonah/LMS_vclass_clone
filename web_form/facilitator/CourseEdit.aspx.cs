using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.facilitator
{
    public partial class CourseEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadContentDetails();
            }
        }

        private void LoadContentDetails()
        {
            string courseId = Session["CourseId"] as string;
            string contentId = Session["ContentId"] as string;

            if (!string.IsNullOrEmpty(courseId) && !string.IsNullOrEmpty(contentId))
            {
                try
                {
                    Guid courseGuid = Guid.Parse(courseId);
                    Guid contentGuid = Guid.Parse(contentId);

                    using (var context = new LMSContext())
                    {
                        

                        // Retrieve the specific content item along with related files
                        var content = context.CourseMaterials
                                              .Include(cm => cm.Files) // Load related files
                                              .FirstOrDefault(cm => cm.Id == contentGuid && cm.CourseId == courseGuid);

                        if (content != null)
                        {
                            // Populate controls with existing data
                            txtEditMaterialTitle.Text = content.Title;
                            txtEditMaterialContent.Text = content.Content; 

                            // Bind files to repeater
                            FilesRepeater.DataSource = content.Files;
                            FilesRepeater.DataBind();
                        }
                        else
                        {
                            lblEditMessage.Text = "Content not found.";
                            lblEditMessage.CssClass = "alert alert-danger";
                        }
                    }
                }
                catch (FormatException)
                {
                    lblEditMessage.Text = "Invalid parameters.";
                    lblEditMessage.CssClass = "alert alert-danger";
                    lblEditMessage.Visible = true;

                }
                catch (Exception ex)
                {
                    lblEditMessage.Text = "An error occurred: " + ex.Message;
                    lblEditMessage.CssClass = "alert alert-danger";
                    lblEditMessage.Visible = true;

                }
            }
            else
            {
                lblEditMessage.Text = "Missing parameters.";
                lblEditMessage.CssClass = "alert alert-danger";
                lblEditMessage.Visible = true;

            }
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string courseId = Session["CourseId"] as string;
            string contentId = Session["ContentId"] as string;

            if (!string.IsNullOrEmpty(courseId) && !string.IsNullOrEmpty(contentId))
            {
                try
                {
                    Guid courseGuid = Guid.Parse(courseId);
                    Guid contentGuid = Guid.Parse(contentId);

                    using (var context = new LMSContext())
                    {
                        var content = context.CourseMaterials
                                     .Include(cm => cm.Files)  
                                     .FirstOrDefault(cm => cm.Id == contentGuid && cm.CourseId == courseGuid);

                        if (content != null)
                        {
                            content.Title = txtEditMaterialTitle.Text;
                            content.Content = txtEditMaterialContent.Text;

                            // Handle file uploads
                            if (fileUploadEditMaterial.HasFiles)
                            {
                                foreach (HttpPostedFile uploadedFile in fileUploadEditMaterial.PostedFiles)
                                {
                                    // Save the uploaded file to the server and add its details to the database
                                    string fileName = Path.GetFileName(uploadedFile.FileName);
                                    string filePath = Server.MapPath("~/Uploads/Materials/") + fileName;
                                    uploadedFile.SaveAs(filePath);

                                    var file = new CourseMaterialFileDB
                                    {
                                        Id = Guid.NewGuid(),
                                        FileName = fileName,
                                        MaterialId = content.Id
                                    };

                                    context.CourseMaterialFiles.Add(file);
                                }
                            }

                            context.SaveChanges();

                            lblEditMessage.Text = "Content updated successfully.";
                            lblEditMessage.CssClass = "alert alert-success";
                            lblEditMessage.Visible = true;
                        }
                        else
                        {
                            lblEditMessage.Text = "Content not found.";
                            lblEditMessage.CssClass = "alert alert-danger";
                            lblEditMessage.Visible = true;

                        }
                    }
                }
                catch (Exception ex)
                {
                    lblEditMessage.Text = "An error occurred: " + ex.Message;
                    lblEditMessage.CssClass = "alert alert-danger";
                    lblEditMessage.Visible = true;

                }
            }
            else
            {
                lblEditMessage.Text = "Missing parameters.";
                lblEditMessage.CssClass = "alert alert-danger";
                lblEditMessage.Visible = true;

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Redirect to the previous page or any other page
            Response.Redirect(Page.GetRouteUrl("FacManageCourse", null));
        }

        protected void FilesRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DeleteFile")
            {
                Guid fileId = Guid.Parse(e.CommandArgument.ToString());

                using (var context = new LMSContext())
                {
                    var file = context.CourseMaterialFiles.FirstOrDefault(f => f.Id == fileId);

                    if (file != null)
                    {
                        string filePath = Server.MapPath("~/Uploads/Materials/") + file.FileName;

                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }

                        context.CourseMaterialFiles.Remove(file);
                        context.SaveChanges();

                        // Reload content details to update the files list
                        LoadContentDetails();
                    }
                }
            }
        }

    }
}
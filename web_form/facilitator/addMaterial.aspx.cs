using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.facilitator
{
    public partial class addMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CourseId"] != null)
                {
                    string courseId = Session["CourseId"].ToString();
                }
                else
                {
                    Response.Redirect(Page.GetRouteUrl("FacCourse"));
                }
            }
        }

        protected void btnUploadMaterial_Click(object sender, EventArgs e)
        {
            string materialTitle = txtMaterialTitle.Text.Trim();
            string materialContent = txtMaterialContent.Text; // Retrieve content from CKEditor control

            // Validate the material title
            if (string.IsNullOrEmpty(materialTitle))
            {
                lblMaterialMessage.Text = "Please enter a material title.";
                lblMaterialMessage.CssClass = "alert alert-danger mt-3";
                lblMaterialMessage.Visible = true;
                return;
            }

            // Retrieve CourseId from session
            Guid courseId;
            if (Session["CourseId"] == null || !Guid.TryParse(Session["CourseId"].ToString(), out courseId))
            {
                lblMaterialMessage.Text = "Invalid course. Please try again.";
                lblMaterialMessage.CssClass = "alert alert-danger mt-3";
                lblMaterialMessage.Visible = true;
                return;
            }

            try
            {
                using (var context = new LMSContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            // Create and save the CourseMaterialDB object
                            var courseMaterial = new CourseMaterialDB
                            {
                                Title = materialTitle,
                                Content = materialContent,
                                CourseId = courseId
                            };

                            context.CourseMaterials.Add(courseMaterial);
                            context.SaveChanges();

                            // Check if any files are uploaded
                            if (fileUploadMaterial.HasFile)
                            {
                                string uploadDir = "~/Uploads/Materials/";
                                string serverPath = Server.MapPath(uploadDir);

                                // Ensure the directory exists
                                if (!Directory.Exists(serverPath))
                                {
                                    Directory.CreateDirectory(serverPath);
                                }

                                foreach (var file in fileUploadMaterial.PostedFiles)
                                {
                                    if (file.ContentLength > 524288000)
                                    {
                                        lblMaterialMessage.Text = "Error: One or more files exceed the 500MB size limit.";
                                        lblMaterialMessage.CssClass = "alert alert-danger mt-3";
                                        lblMaterialMessage.Visible = true;
                                        transaction.Rollback();
                                        return;
                                    }

                                    string fileName = Path.GetFileName(file.FileName);
                                    string filePath = Path.Combine(serverPath, fileName);

                                    try
                                    {
                                        file.SaveAs(filePath);

                                        // Save the relative file path to the database
                                        var courseMaterialFile = new CourseMaterialFileDB
                                        {
                                            FilePath = Path.Combine(uploadDir, fileName), // Save the relative path
                                            FileName = fileName,
                                            MaterialId = courseMaterial.Id
                                        };

                                        context.CourseMaterialFiles.Add(courseMaterialFile);
                                    }
                                    catch (Exception fileEx)
                                    {
                                        lblMaterialMessage.Text = $"Error saving file '{fileName}': {fileEx.Message}";
                                        lblMaterialMessage.CssClass = "alert alert-danger mt-3";
                                        lblMaterialMessage.Visible = true;
                                        transaction.Rollback();
                                        return;
                                    }
                                }

                                context.SaveChanges();
                            }

                            // Commit the transaction
                            transaction.Commit();

                            lblMaterialMessage.Text = "Material uploaded successfully.";
                            lblMaterialMessage.CssClass = "alert alert-success mt-3";
                            lblMaterialMessage.Visible = true;

                            // Clear form after successful upload
                            txtMaterialTitle.Text = string.Empty;
                            txtMaterialContent.Text = string.Empty; // Clear CKEditor content
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // Rollback the transaction in case of an error
                            lblMaterialMessage.Text = $"Error: {ex.Message}";
                            lblMaterialMessage.CssClass = "alert alert-danger mt-3";
                            lblMaterialMessage.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMaterialMessage.Text = $"Error: {ex.Message}";
                lblMaterialMessage.CssClass = "alert alert-danger mt-3";
                lblMaterialMessage.Visible = true;
            }
        }



    }
}
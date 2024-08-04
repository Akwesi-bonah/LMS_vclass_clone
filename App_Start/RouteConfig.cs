using System.Web.Routing;

namespace vclass_clone
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Ignore routes to axd files
            routes.Ignore("{resource}.axd/{*pathInfo}");

            routes.MapPageRoute("AdminList", "admin/list", "~/web_form/admin/userList.aspx");

            routes.MapPageRoute("AdminAdd", "admin/add", "~/web_form/admin/userAdd.aspx");
            routes.MapPageRoute("AdminEdit", "admin/edit/{id}", "~/web_form/admin/userEdit.aspx");


            routes.MapPageRoute("FacilitatorList", "facilitator/list", "~/web_forms/admin/FacilitatorList.aspx");
            routes.MapPageRoute("FacilitatorAdd", "facilitator/Add", "~/web_forms/admin/FacilitatorAdd.aspx");
            routes.MapPageRoute("FacilitatorEdit", "facilitator/Edit", "~/web_forms/admin/FacilitatorList.aspx");

            routes.MapPageRoute("StudentList", "student/list", "~/web_forms/admin/studentList.aspx");
            routes.MapPageRoute("StudentAdd", "student/Add", "~/web_forms/admin/studentAdd.aspx");
            routes.MapPageRoute("StudentEdit", "student/Edit", "~/web_forms/admin/studentList.aspx");

            routes.MapPageRoute("CourseList", "course/list", "~/web_forms/admin/CourseList.aspx");
            routes.MapPageRoute("CourseAdd", "course/Add", "~/web_forms/admin/CourseAdd.aspx");
            routes.MapPageRoute("CourseEdit", "course/Edit", "~/web_forms/admin/CourseEdit.aspx");
            routes.MapPageRoute("CourseAssignList", "course/assign/list", "~/web_forms/admin/CourseAssignList.aspx");




        }
    }

}
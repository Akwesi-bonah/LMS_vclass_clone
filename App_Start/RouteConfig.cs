using System.Web.Routing;

namespace vclass_clone
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Ignore routes to axd files
            routes.Ignore("{resource}.axd/{*pathInfo}");


            routes.MapPageRoute("Login", "defualt/login", "~/web_form/auth/login.aspx");
            routes.MapPageRoute("AdminDashboard", "admin/dashboard", "~/web_form/admin/AdminIndex.aspx");

            routes.MapPageRoute("AdminList", "admin/list", "~/web_form/admin/userList.aspx");

            routes.MapPageRoute("AdminAdd", "admin/add", "~/web_form/admin/userAdd.aspx");
            routes.MapPageRoute("AdminEdit", "admin/edit/{id}", "~/web_form/admin/userEdit.aspx");


            routes.MapPageRoute("FacilitatorList", "facilitator/list", "~/web_form/admin/facilitatorList.aspx");
            routes.MapPageRoute("FacilitatorAdd", "facilitator/Add", "~/web_form/admin/FacilitatorAdd.aspx");
            routes.MapPageRoute("FacilitatorEdit", "facilitator/Edit", "~/web_form/admin/FacilitatorList.aspx");

            routes.MapPageRoute("StudentList", "student/list", "~/web_form/admin/studentList.aspx");
            routes.MapPageRoute("StudentAdd", "student/Add", "~/web_form/admin/studentAdd.aspx");
            routes.MapPageRoute("StudentEdit", "student/Edit", "~/web_form/admin/studentList.aspx");

            routes.MapPageRoute("CourseList", "course/list", "~/web_form/admin/Course.aspx");
            routes.MapPageRoute("CourseAdd", "course/Add", "~/web_form/admin/CourseAdd.aspx");
            routes.MapPageRoute("CourseAssignList", "course/assign/list", "~/web_form/admin/CourseAssigment.aspx");




        }
    }

}
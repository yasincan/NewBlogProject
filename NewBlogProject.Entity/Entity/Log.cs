namespace NewBlogProject.Entity.Entity
{
    public class Log : ModelBase
    {
        public string UserName { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string InformationMessage { get; set; }
    }
}

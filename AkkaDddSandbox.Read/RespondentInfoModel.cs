namespace AkkaDddSandbox.Read
{
    public class RespondentInfoModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TimeZone { get; set; }
        public bool IsReleased { get; set; }
        public int AuthorizedTasks { get; set; }
    }
}
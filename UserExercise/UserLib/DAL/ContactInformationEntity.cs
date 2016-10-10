namespace EmployeeLib.DAL
{
    public sealed class ContactInformationEntity
    {
        public long ID_ContactInformation { get; set; }

        public long UserID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

namespace EMEHospitalWebApp.Data {
    public class UniqueData {
        public static string NewId => Guid.NewGuid().ToString();
        public string Id { get; set; } = NewId;
    }
}

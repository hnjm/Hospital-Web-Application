namespace EMEHospitalWebApp.Data {
    public abstract class UniqueData {
        public static string NewId => Guid.NewGuid().ToString();
        public string Id { get; set; } = NewId;
    }
}

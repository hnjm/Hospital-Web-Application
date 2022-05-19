namespace EMEHospitalWebApp.Data {
    public abstract class NamedData : UniqueData {
        public string Code { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}

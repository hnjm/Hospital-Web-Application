using System.ComponentModel.DataAnnotations;

namespace EMEHospitalWebApp.Data {
    public abstract class UniqueData {
        public static string NewId => Guid.NewGuid().ToString();
        protected static byte[] empty => Array.Empty<byte>();
        public string Id { get; set; } = NewId;
        [Timestamp] public byte[] Token { get; set; } = empty;
    }
}

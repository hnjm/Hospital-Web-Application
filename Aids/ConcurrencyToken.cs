namespace EMEHospitalWebApp.Aids {
    public static class ConcurrencyToken {
        public static string ToStr(byte[]? token = null) {
            return (token ?? Array.Empty<byte>()).Aggregate(string.Empty, (current, b) => current + b);
        }
        public static byte[] ToByteArray(string? token = null) {
            var l = new List<byte>();
            foreach (var c in token ?? GetRandom.String(8,8)) l.Add(Convert.ToByte(c));
            return l.ToArray();
        }
    }
} 
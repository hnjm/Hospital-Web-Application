namespace EMEHospitalWebApp.Aids {
    public static class Chars {
        public static bool IsNameChar(this char x) => char.IsLetter(x);
        public static bool IsFullNameChar(this char x) => IsNameChar(x) || x is '.' or '`';
    }
}

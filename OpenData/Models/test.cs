namespace OpenData.Models
{
    public class ViewModel
    {
        public List<Park> ParkList { get; set; }
    }

    public class Park
    {
        public int Index { get; set; }
        public string 公園名稱 { get; set; }
        public string 行政區 { get; set; }
        public string 管理單位 { get; set; }
        public string 組合遊具數量 { get; set; }
        public string 磨石滑梯數量 { get; set; }
        public string 鞦韆數量 { get; set; }
        public string 翹翹板數量 { get; set; }
        public string 搖搖樂數量 { get; set; }
        public string 攀爬組數量 { get; set; }
        public string 戲沙坑數量 { get; set; }
        public string 擺盪船索數量 { get; set; }
        public string 其他數量 { get; set; }
        public string X坐標 { get; set; }
        public string Y坐標 { get; set; }
        public string JSON { get; set; }
    }


}

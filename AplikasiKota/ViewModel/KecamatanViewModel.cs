namespace AplikasiKota.Web.ViewModel
{
    public class KecamatanViewModel
    {
        public int Id { get; set; }
        public string NamaKecamatan { get; set; }
        public string KodeKecamatan { get; set; }
        public int IdKota { get; set; }
        public KotaViewModel Kota { get; set; }
    }
}

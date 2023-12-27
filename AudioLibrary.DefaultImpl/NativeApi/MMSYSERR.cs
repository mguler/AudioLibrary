
namespace AudioLibrary.DefaultImpl.NativeApi
{
    public static class MMSYSERR
    {
        public const int NO_ERROR = 0;
        //Belirtilen kaynak zaten ayrılmış durumda.Örneğin, belirtilen ses giriş aygıtı veya kaynak başka bir uygulama tarafından kullanılmaktadır
        public const int ALLOCATED = 1;
        //Belirtilen cihaz tanımlayıcısı(device identifier) geçerli bir aralıkta değil.Bu, kullanılan cihazın tanımlayıcısının geçerli olmadığı veya mevcut olmadığı anlamına gelir
        public const int BAD_DEVICE_ID = 2;
        //Hiçbir cihaz sürücüsü bulunamıyor. Bu durum, bilgisayarınızda uygun bir ses sürücüsü olmadığında veya sürücü hatalı olduğunda ortaya çıkabilir.
        public const int NO_DRIVER = 3;
        //Bellek ayrılamıyor veya kilitlenemiyor. Bellek yetersiz olduğunda veya bellek ayrılamıyorsa bu hata alınabilir.
        public const int NOMEM = 4;
        //Desteklenmeyen bir dalgaformu ses formatı ile açmaya çalışıldı. Ses giriş aygıtını belirli bir formatta açarken, bu formata uygun olmayan bir format kullanılmış olabilir
        public const int BAD_FORMAT = 5;
    }
}

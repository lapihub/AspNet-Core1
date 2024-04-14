using WebApi.Models;

namespace WebApi.Data;

public static class DataStore
{
    public static List<Product> Products { get; set; } =
    [
        //new() { Id = 1017499, Name = "Google Nest Hub II - Charcoal", Price = 890, ProductImage = "https://www.netonnet.se/GetFile/ProductImagePrimary/ljud/hogtalare/smartahogtalare/google-c3-charcoal(1017499)_510295_11_Normal_Large.webp" },
        //new() { Id = 1026724, Name = "Apple iPhone 14 128GB - Midnight", Price = 7990, ProductImage = "https://www.netonnet.se/GetFile/ProductImagePrimary/mobil-smartwatch/mobiltelefoner/iphone/apple-iphone-14-128gb-midnight(1026724)_527786_1_Normal_Large.webp" },
        //new() { Id = 1029554, Name = "Samsung TQ65Q70CATXXC", Price = 9990, ProductImage = "https://www.netonnet.se/GetFile/ProductImagePrimary/tv/56-70tum/samsung-tq65q70catxxc(1029554)_569628_1_Normal_Large.webp" },
    ];
}
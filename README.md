### LİSTE, YIĞIT, KUYRUK ve ÖNCELİKLİ KUYRUK VERİ YAPILARI

Proje tek kişiliktir. Her bir öğrenci kendi başına hazırlayacaktır. İstenen programlar ilgili öğrenci tarafından yazılıp tamamlandıktan sonra rapor, kodlar arka arkaya getirilip her maddede istenen bilgiler de yazılarak tamamlanacaktır. Raporda, her bir soru için soru numarası, ilgili kaynak kod, istenen diğer bilgiler ve ekran görüntüsü yer almalıdır. Programlar ve Rapor, belirtilecek tarihe kadar EGEDERS’te Proje 2 Yükleme bağlantısından yüklenmelidir. Doğru çalışmasa bile, kendi başınıza yapmanıza teşvik açısından, fazla puan kırılmayacaktır. Kopya ödev ise istenmemektedir. Gerekirse bazı öğrenciler proje kontrolüne çağrılabilir. C# veya Java dilleri tercih edilmelidir. 

## 1)	Türkiye’deki Milli Parklar Listesi (30 puan)

Türkiye’de bulunan 48 adet Milli Parkın isimleri, bulunduğu iller, milli park ilan edildiği tarihler ve yüzölçümleri (hektar)  https://tr.wikipedia.org/wiki/T%C3%BCrkiye%27deki_mill%C3%AE_parklar_listesi https://www.tarimorman.gov.tr/DKMP/Belgeler/Korunan%20Alanlar%20Listesi/MP-WEB-Son.pdf bağlantılarında verilmektedir. Bu verilerden Milli Park nesnelerini oluşturarak ilgili bileşik veri yapısına yerleştiren etkin C# veya Java programını yazınız:

a)	Aşağıdaki sahaları içeren (uygun veri tiplerini / veri yapılarını siz belirleyiniz) bir Milli park sınıfı oluşturunuz: (5)

MilliPark sınıfı (MilliPark_Adı, İl_Adları, İlan_Yılı, Yüzölçümü) 
	
Bir Milli Parkın bulunduğu illerin adlarını tutmak için Generic List kullanabilirsiniz. Milli Park ilan edildiği tarihin sadece yılını tutmanız yeterli olmakla birlikte dileyen tarih (gün.ay.yıl formatında) olarak tutabilir. 

b)	2 elemanlı bir Generic List dizisi oluşturunuz (Şekil 1). Dizinin her bir elemanı Milli Park sınıfı tipinde elemanlardan oluşan birer Generic liste içersin. Verileri sıra ile yukarıdaki bağlantılardan birinden alarak, önce 1. Milli Parka ilişkin nesneyi oluşturunuz; Ardından yüzölçümü 15.000 hektardan küçük ise, dizinin 0. elemanındaki listenin, büyük ise 1. elemanındaki listenin sonuna ekleyiniz. Sonra, kalan Milli Park nesnelerini de belirtilen kritere göre uygun listeye ekleyiniz.  [Dileyenler ön çalışma olarak, ekleme metodunu yazmadan önce algoritmasını / sözdekodu A4 kağıdına yazabilirler.] (15)

Şekil 1: Generic Liste’lerden oluşan dizi (Bileşik Veri Yapısı)
c)	Dizideki her bir listedeki bilgilerin tümünü ekrana yazdıran metodu yazınız. Her bir listedeki elemanların yüzölçümleri toplamını da hesaplayıp yazdırınız. (10)
2) YIĞIT ve KUYRUK (20 puan)
a) Ders kitabındaki Chapter 4’te LISTING 4.1’deki yığıt (sayfa 120-121) programını inceleyiniz, ilgili bölümleri okuyunuz. Milli Park (sınıfı nesnelerinden oluşan) Yığıtı oluşturacak şekilde kodu güncelleyiniz veya kendiniz yazınız. Soru 1’deki tüm Milli Parkları, oluşturduğunuz Yığıta ekleyiniz (bilgileri dosyadan da, oluşturduğunuz Listelerden de çekebilirsiniz, size kalmış). Yığıttaki tüm elemanları çıkartıp ekrana Milli Park bilgilerini ekrana yazdırınız. (10) 
b) Ders kitabındaki Chapter 4’te LISTING 4.4’teki kuyruk (138-140) programını inceleyiniz, ilgili bölümleri okuyunuz. 2a.’daki işlemi Kuyruk (sınıfı) Veri Yapısı için tekrarlayınız. (10)

3) ÖNCELİKLİ KUYRUK (20 puan)

C# veya Java’da artan sırada ve O(1) ekleme zamanlı (ama en öncelikli elemanı silmenin daha yavaş olduğu) bir Öncelikli Kuyruk (sınıfı) tasarlayarak yazınız (Liste sıralı tutulmayacak, eleman sona eklenecek, eleman silme metodu ise yüzölçümü en küçük olan Milli Parkı arayarak onu silecek). Milli Park sınıfı tipindeki elemanları tutmak için List hazır veri yapısı kullanmalısınız. ÖncelikliKuyruk Sınıfının gerekli tüm metotlarını (ekle, sil, bosMu, yapılandırıcı) ve içeriklerini yazmalısınız. Soru 1’deki veriler üzerinde test ediniz, Milli Parkları Yüzölçümlerine göre öncelikli şekilde sırayla silerek (küçükten büyüğe) yazdırınız. (20)
İpucu : Yeni gelen elemanı, altyapıda kullandığınız listenin sonuna ekleyebilirsiniz ve en küçük değere sahip yani en öncelikli elemanı arayarak silebilirsiniz. 
Not: Elemanları Dizi‘de tutan yarı puan alır. 

4) (20 puan)
a) Her bir elemanı tamsayı olan bir kuyruk tasarlayarak yazınız. Bir marketteki tek kasada bekleyen müşterilerin sepetlerinde sıra ile 8, 9, 6, 7, 10, 1, 11, 5, 3, 4, 2 adet ürün olsun. Kasiyerin her bir ürünü okutmasının 3 saniye sürdüğünü varsaydığınızda Kuyruk (FIFO yapısındaki)’taki her bir müşterinin işlem tamamlanma sürelerini ve bu kasa için müşterilerin ortalama işlem tamamlanma süresini bulunuz (ödeme gibi işlemlerin süresini ihmal edebilirsiniz). (5)
b) 3. Sorudaki ÖncelikliKuyruk sınıfı ve metotlarını tamsayılar için artan sırada işleyecek şekilde güncelleyiniz. 3. sorudaki sınıfınızı kaybetmemek için yedekleyiniz. Bu ÖncelikliKuyruk sınıfını kullanarak veri yapısındaki her bir müşterinin işlem tamamlanma sürelerini ve bu kasa için ortalama işlem tamamlanma süresini bulunuz, sonuçları rapora ekleyiniz. (10)
c) Kasalarda Queue ve PQ ve yapıları kullanımının sonuçlarını kısaca karşılaştırınız. Öncelikli Kuyruk (PQ) düzeni, ortalama işlem tamamlanma süresi açısından daha verimli olmaktadır. Ancak dezavantajları nelerdir? Hangi durumlarda kullanılamaz. Kısaca açıklayınız. (5)


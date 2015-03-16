=Türkçe Hâller=

Kodu açık bir dilbilgisi aracı. Amacı bir Türkçe ismi istenilen hâle göre çekimlemek. Yani daha doğrusu, hâle göre eklenecek "çekim ek"ini kurallı bir biçime sokmak. Sesli uyumlarını ve diğer Türkçe kurallarını dikkate alarak.

Yıllardır kanayan bir yaraya parmak bastığımızın farkındayız. Rica ederiz.

*İyi haber*: İki arkadaş bu koda devam etmiş. Ortaya "Türkçe Ekler" çıkmış. Tebrikler. http://code.google.com/p/turkceekler

==Kodun kullanımı:==
{{{
string result = TurkceHaller.Uygula("Ahmet", TurkceHaller.IsminHali.Yonelme);
}}}

*Örnek sonuçlar:*
  * Yönelme
    * Ahmet > Ahmet'e
    * Masa > Masa'ya
    * Gül > Gül'e
    * Şeftali > Şeftali'ye
  * Gösterme
    * Elma > Elma'yı
    * Armut > Armut'u
    * İncir > İncir'i
    * Üzüm > Üzüm'ü
    * Büyü > Büyü'yü
  * Bulunma
    * Küvet > Küvet'te
    * Masa > Masa'da
    * İş > İş'te
    * Kitap > Kitap'ta
  * Çıkma
    * Kitap > Kitap'tan
    * Ölüm > Ölüm'den
  * Tamlama
    * Ölüm > Ölüm'ün
    * Başarı > Başarı'nın

İlginizi çekiyorsa, sizi "[http://code.google.com/p/turkcehaller/downloads/list Downloads]" sayfasına alalım.

=Bilinen Durumlar=

Bu C# sınıfını kullanarak "özel isim" mahiyetindeki ifadelere hâl ekleri eklersiniz. Gerekli olan tek tırnak karakterini de biz koyuyoruz.

Ancak içerideki algoritma, ek çekimlemeye matematiksel olarak yaklaştığı için iflas ettiği bazı durumlar olabilir. Çünkü Türkçe bazen yalın matematiğe uymuyor. Tam doğru neticeyi alabilmek için bir kelime sözlüğüne ihtiyacımız var. Biz en az düzeyde kod ve bilgi ile bu işi başarabilmek istedik. O nedenle %100 başarılı bir çekimlemeyi vaad etmiyoruz.

"Tamlama" dediğimiz birleşik kelime yapılarını matematik kurtamıyor. Meselâ "Çılgın Başarı" ve "Köy Kaşarı" şeklinde iki tamlamamız olsun. Bunların "gösterme" hâlleri şöyle olacaktır:

  * Çılgın Başarı > Çılgın Başarı'Yı
  * Köy Kaşarı > Köy Kaşarı'Nı

Açıkça farkedeceğiz ki bu iki tamlama hemen hemen aynı harflerle bitmesine rağmen eklenen "ek"le araya giren kaynaştırma harfi farklı oluyor. İşte bu tip durumlar için algoritmamızın yapabileceği bir şey bulunmuyor malesef. Ama tek bir kelime ise bu, üstesinden geliyoruz: Başarı > Başarı'yı veya Kaşar > Kaşar'ı yapabiliyoruz.

Tamlamalarla ilgili sıkıntı sadece "tamlama" hâlinde bulunmuyor: Çılgın Başarı'nın veya Köy Kaşarı'nın gibi.


=Ek Bilgi - İsmin Hâlleri=

Kaynak:http://sozluk.sourtimes.org/show.asp?id=5514074

türkçede bulunan altı isim hali, uluslararası literatürde, yani ecnebice olan kaynaklarda şu isimlerle adlandırılır:

* yalın:nominative(ev)

* gösterme(i):accusative(evi)

* yönelme(e):dative(eve)

* bulunma(de):locative(evde)

* çıkma(den):ablative(evden)

* tamlama(in):genitive ya da posessive(evin)

bunların dışında ismin halleri iyelik adılları(genitive pronoun)(türkçede benimki, seninki; ingilizcede mine, yours vs), dönüşlü adıllar(reflexive pronouns)(türkçede kendi adılı; ingilizcede myself, yourself vs) diye iki hali daha bulunur.

her dilde bu durumlara rastlanır. öte yandan, kimi dillerde çoğu durum için farklı kip kullanılırken(örn:türkçe, almanca) kimi dillerde ise bazı durumlar sadece adıla getirilen ufak değişiklerle, bazıları da hiç etkisini göstermeden belirtilir(örn: ingilizce, fransızca).

şöyleki, türkçede "bana bak" dative bir durumdur, ingilizcede "look at me" diye adıl değişmesi(i - me) görülür. "beni sev" accusative bir durumdur ama ingilizcede "love me" şeklinde adıl değişmesine uğramadan geçer. ingilizcede locative ve ablative durumlarda ise nominative adıl hiç değişikliğe uğramaz. örnekler çoğaltılabilir.

edit: bu ismin halleri(case) işi oldukça karışık. yukarıdakilerin yanında daha bir dolu durum daha var ama kimi eklerle, kimi edatlarla gösterilmekte. bulduğum diğer halleri de yazayım, araştırması size kalsın:

vocative, inessive, elative, illative, adessive, allative, essive, partitive, translative, abessive, instructive, comitative... daha da vardır allah bilir...

ayrıca (bkz: gramer)

----

http://www.evcil.net

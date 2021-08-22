using System;
using System.Text;
using Microsoft.Extensions.Primitives;


#region string
/*
 * String reference type olmagina baxmayaraq keywordu var,
 * heap-de saxlanilir.
 *
 * String eslinde char Array-dir.
 *
 * Yeni normalda Value typelardan danisarken number bir data varsa
 * onu int(keyword-dur) ve sair deye teyin ede bilirik.
 * Reference typeda ise istisna stringdir keywordle teyin edile bilir.
 *
 * ev tapsirigi : string method-larini arasdirin 
 */


//int a = 5;
//string b = "Kamran";
//for (int i = 0; i < b.Length; i++)
//{
//    Console.WriteLine(i);
//}
#region null vs empty 
/*
 * Value type-lar null deyeri ala bilmesede reference type-larda bu bele deyil null ola
 * bilerler.
 * NULL: Eger bir deyisen/nullable/reference  null-dursa bu deyisen RAM-da yerseldirilmeyib demekdir.
 * Empty : Eger bir deyisen/nullable/reference empty-ise bu deyisenin deyeri yoxdur demekdir,
 * null ile cox oxsar gorunse bele deyeri olmasa bele RAM_Da yerlesmis/depolanmis olur bele
 * deyisenler.
 * NULL Sadece reference type-larda oldugu halda empty butun deyerlere verile biler.
 *
 * NULL olan bir deyisen uzerinde her hansi bir emeliyyat apararken RUNTIME xetasi alacagiq,
 * EMPTY ise eksine xeta vermir emeliyyat apara bilirik
 *
 * QEYD: Default verilen deyerler empty ile eynidir.
 */
//string a = "";
//string b = null;
//string c = string.Empty;
//string d = " ";

#region IsNullOrEmpty IsNullOrWhiteSpace

//string x = "";

//if (x != "") ;
//if (x != string.Empty && x != null) ;
//if (x != string.Empty && x is not null) ;
//if (string.IsNullOrEmpty(x) && string.IsNullOrWhiteSpace(x)) ;
//if (string.IsNullOrWhiteSpace(x)) ;
#endregion

#endregion
#region string + operatoru
/*
 * bu operatoru istifade ederek string ifadeleri birlesdire bilerik , lakin
 * maliyyetli bir emeliyyat etmis olacagiq buna gorede cox istifadesi meslehet gorulmur,
 * sebeb ise string-in deyismez olmasidir  + la yeniden basqa bir deyer yaranir.
 */

//int a = 5;
//double b = 10;// double

//string name = "Resad";
//string surname = "Memmedli";
//string fullname = name + surname;

//for (int i = 0; i < name.Length; i++)
//{
//    fullname += name[i];  // Resad Memmedov R //Resad Memmedov RE
//}
//Console.WriteLine(" "+name+" ");
//Console.WriteLine(fullname);
#endregion
#region arraySegment - stringSegment struct
//arraySegment
/*
 * ArraySegment deyeri yeniden kopyalamadan evellceden teyin edilmis her hansisa deyisenin
 * deyerlerine reference ede bilmeyimize imkan verir.
 */
//int[] numbers = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };// 30 -70
//int[] numbers2 = numbers[2..7];

//numbers2[0] *= 10;
//numbers2[1] *= 10;
//numbers2[2] *= 10;
//numbers2[3] *= 10;
//numbers2[4] *= 10;

//ArraySegment<int> segment1 = new ArraySegment<int>(numbers);
//ArraySegment<int> segment2 = new ArraySegment<int>(numbers, 2, 7);
//var i = segment1[0];
// stringSegment
/*
 * StringSegment ArraySegmentle birebir eyni isi gormektedir tek ferqi string ifade/deyerler
 * ucun istifade edilmesidir.
 * Substring , Trim ve sair kimi methodlarin istifadesi zamani maliyyetden qacinmaq ucun istifade
 * edilir.
 *
 * StringSegment tipini istifade ede bilmek ucun Microsoft.Extensions.Primitives nuget package
 *  yuklemek lazimdir.
 *
 *
 */
//string text = "Pragmatech CSharp-02";
//text.Substring(0, 5);
//StringSegment stringSegment = new StringSegment(text);
//StringSegment stringSegment1 = new StringSegment(text, 2, 5);
//Console.WriteLine(stringSegment1);
#endregion
#region stringBuilder class
/*
 * Arxa planda StringSegment istifade edir suretli ve daha az maliyyetli
 * istifadeye imkan yaradir.
 */
// maliyyetli bir emeliyyat
//string name = "Parviz";
//string surname = "Aliyev";
//string fullname = name + surname;
//Console.WriteLine(fullname);
////
//StringBuilder builder = new StringBuilder();
//builder.Append(name);
//builder.Append(" ");
//builder.Append(surname);

//Console.WriteLine(builder.ToString());
#endregion
#region string - loop



#endregion
#endregion

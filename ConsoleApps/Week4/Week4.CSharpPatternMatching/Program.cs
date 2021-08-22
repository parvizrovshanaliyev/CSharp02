using System;

#region chsarp 7.0 pattern matching

/*
 * tez tez istifade etdiyimiz kod bloklarini daha qisa ve effektiv yazmagimiza komek edir.
 *
 * c# 7.0 ile gelib  9.0 da dahada inkisaf etdirilmisdir.
 *
 * Pattern Matching dedikde  qeliblesmis kod bloklari
 *
 * basa duse bilerik.
 *
 */

// c# 7.0 ile gelen patternler

#region type pattern
/*
 * Object icerisindeki her hansisa bir tipin
 *
 * check edilmesinde istifade edilen is operatorunun
 *
 * pattern/qelib formasidir.
 *
 * is ile check edilen tipin bir basa lazim olan tipe cevrilmesini temin edir.
 */
// normal istifade

//object obj = "CSharp-02";

//if (obj is string)
//{
//    string a = obj as string;
//    Console.WriteLine("stringdir:{0}",a);

//}else if (obj is int)
//{
//    int b = (int) obj;
//    Console.WriteLine("VALUE TYPE INT");
//}
// pattern

//if (obj is string a)
//{
//    Console.WriteLine("stringdir:{0}", a);
//}
//else if (obj is int b)
//{
//    Console.WriteLine("VALUE TYPE INT");
//}

//a = "";
//Console.WriteLine(a);

#region example
/*
 * bu patternde teyin edilen deyisenimiz if else if icerisinde yazilmasina
 *
 * baxmayaraq ozunden bir ust skopa aid olur yeni if skopunun deyil ondan ustedki skop
 *
 * buna gorede hemin ust skopda deyisenimiz elcatandir . Lakin global olan bu deyisen ifden
 *
 * kenarda null olma ehtimalina gore istifade edile bilmir ancaq her hansi bir deyer verib istifade ede bilersiz.
 *
 *
 */

#endregion


#endregion

#region constant pattern
/*
 * bu pattern elimizde olan her hansisa deyeri sabit bir deyerle
 *
 * qashilasdirmagimizi temin edir ,== temin etdiyi 
 */
//object a = "Ferid";

//if (a is "Ferid")
//{
//    Console.WriteLine(a);
//}

//Console.WriteLine(a is int);
//Console.WriteLine(a is 123);

#region example
/*
 *
 */

#endregion

#endregion

#region var pattern
/*
 * var keyword-u runtime zamani eldeki deyerin tipine burunmektedir.
 *
 * var pattern type patternin daha qisa variantidir.
 *
 * runtime zamani
 *
 * deyisen teyin etdiyimiz var-la arasinda ferq var
 */
//var c = 123;
//c.GetHashCode();
//dynamic f = "gghh";

//object obj = "Country";
//if (obj is var b)
//{
//    Console.WriteLine(b);
//}



#endregion

#region recursive pattern
/*
 * Bu pattern switch-case bloku uzerine bir cox yenilikler
 * getirmisdir.
 *
 * switch blokunda reference tipli deyisenlerde control edile bilmektedir.
 *
 * c# 7.0 dan evvel evveller switch(value type) yoxlanila bilirdi .
 *
 * switchde istifade edilen when bu patternle geldi ve beraberdirmiden
 *
 * ferqli qarsilastirma emeliyyatlarini temin edir.
 *
 * daxilinde  type pattern ve constant patternler var
 */
#endregion

// c# 9.0 ile gelen patternler
// Pattern Matching Enhancements

#region simple type pattern
/*
 * Type patternle eyn xususiyyetlere malikdir
 *
 * Elave olaraq type daki kimi deyisen adlarini teyin etme mecburiyyetimiz yoxdur.
 */
#endregion

#region relational pattern
/*
 * switch expresiionlarda qarsilastirma emeliyyatlari ucun istifade ede bilerik
 *
 */

//int number = 123;

//string result = number switch
//{
//    < 50 => "50-den kicikdir",
//    > 50 => "50-den boyukdur",
//    _ => "hecbiri"
//};
#endregion

#endregion

Console.ReadLine();

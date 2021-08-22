using System;


#region arrays
/*
 * bir deyisen altinda birden cox eyni tipli deyeri saxlamagimiza
 * imkan verir.
 *
 * Demeli arrayler prosedual programlasdirmanin temel anlayislarindan
 * olmaqla yanasi daha sonra oyreneceyimiz Collection-larinda temelini ozeyini
 * teskil etmektedirler.
 *
 * Reference tipindedirler. Ozlerinde onlarda bir classdir deye bilerik.
 *
 * Demeli bunlar reference type olduqlarindan ramde -heap hissesinde saxlanirlir.
 *
 * Hemcinin Arrayler icerisindeki elemetleri daginiq sekilde deyil indexleyerek,
 *
 * sirali bir sekilde depolayir. Index her zaman 0-dan n-1 qeder gedir.
 *
 * [] - indexer adlanir.
 *
 * arrayler serhedi olan anlayislardir. Yeni nece element teyin edilecek sayi bildirilmelidir.
 *
 * sayi bildirilen arrayler daxil edilen say qeder ramde yer tuturlar (istifade etsekde etmesekde) bu zaman
 *
 * once tipin default deyeri sonra index nomresi qeyd olunur index : value
 *
 * qeyd edilen arrayin serhedini kecsek yeni int [7] 7 elementli bir arraye ondan elave
 * element artira bilmerik. xeta verir.
 */

#region array yaradilmasi


//// array yaradilmasi
// 10 elemetli bir arrayde index 0 n-1,
//int[] ages1 = new int[10];
//int[] ages2 = new[] { 1, 2, 3, 4 };
//int[] ages3 = { 1, 2, 3, 4 };

#endregion

// arrayin elementlerine deyerlerin menimsedilmesi
//ages1[0] = 1;
//ages1[2] = 2;
//ages1[3] = 3;
//ages1[4] = 4;
//ages1[5] = 5;

#region arraylerde loop
//ages1[0] = 1;
//ages1[2] = 2;
//ages1[3] = 3;
//ages1[4] = 4;
//ages1[5] = 5;

//for (int i = 0; i < ages1.Length; i++)
//{
//    ages1[i] = i;
//    Console.WriteLine(i);
//}


#endregion

#region foreach

//string[] products = new string[5];

//for (int i = 0; i < products.Length; i++)
//{
//    products[i] = "product:" + i;
//}

//foreach (var item in products)
//{
//    Console.WriteLine(item);
//}


#endregion

#region reverse

// 5,4,3,2,1
//int[] numbers = new int[] {1, 2, 3, 4, 5};

//for (int i = 0; i < numbers.Length/2; i++)
//{
//    int temp = numbers[i];
//    numbers[i] = numbers[numbers.Length - i - 1];
//    numbers[numbers.Length - i - 1] = temp;

//}

//foreach (var item in numbers)
//{
//    Console.WriteLine(item);
//}
#region kamran varianti

//for (int i = numbers.Length; i > 0; i--)
//{
//    numbers[numbers.Length - i] = numbers[i - 1];

//}

//foreach (var item in numbers)
//{
//    Console.WriteLine(item); 
//}

#endregion

#endregion

#region array class
/*
 * Array class nedir ?
 *
 * class movzusunu OOP-de etrafli baxacayiq.
 *
 * Array olaraq yaradilan deyisenler eslinde Array classindan gelmektedir.(inheritance)
 * Arraylerde array clasindan gelen metodlar ve ozellikler movcuddur.
 *
 */

// normal qaydada array teyin ederken indexer operatorundan istifade etmeliyik
// class olaraq teyin edilerse indexer ehtiyyac yoxdur.
//int[] numbers = new int[3]; // algoritmlerde / operativ istifade edilir
//Array numbers2 = new[]{1,2,3,4};  //

#region array classinin elementlerine deyer verilmesi
//int[] ages1 = new int[10];
//int[] ages2 = new[] { 1, 2, 3, 4 };
//int[] ages3 = { 1, 2, 3, 4 };
/*ages1[0] = 10;*/ // default 0 0 set 10
//Array numbers1 = new int[] { 1, 2, 3 };
//Array numbers2 = new int[3] { 1, 2, 3 };
//Array numbers3 = new[] { 1, 2, 3 };

//2. SetValue
//numbers1.SetValue(10,0);


// deyerin oxunmasi GetValue
//int[] ages2 = new[] {1, 2, 3, 4};
//var number = ages2[0];
//numbers3.GetValue(0);
#endregion

#region methods

#region clear
/*
 * array-in icerisindeki elementlerin deyerini arrayin tipine uygun default deyer
 * menimsedir.
 * yeni silmir default deyer verir.
 */
//Array names = new[] {"Resad", "Ferid", "Kamran", "Zaur", "Elcan", "Avaz"};

//for (int i = 0; i < names.Length; i++)
//{
//    Console.WriteLine(names.GetValue(i));
//}

//Console.WriteLine("+++++++++++++");
//Array.Clear(names,0,names.Length);

//for (int i = 0; i < names.Length; i++)
//{
//    Console.WriteLine(names.GetValue(i));
//}
#endregion

#region copy
/*
 * Bu metodla bir arrayin deyerlerini basqa bir arraye kopyalayiriq.
 */
//Array a2 = new[] {"a", "b"};

//string[] names2 = new string[names.Length];

//Array.Copy(names,names2,names.Length);

#endregion

#region indexOf
/*
 * Bir array-de element olub olmadigini yoxlayir.
 * Axtarilan deyerin index nomresini qaytarir. yoxdursa -1 qaytarir
 */
//Array names = new[] { "Resad", "Ferid", "Kamran", "Zaur", "Elcan", "Avaz" };

//int index = Array.IndexOf(names, "Kamran");

//if (index != -1)
//{
//    Console.WriteLine("sert odendi");
//}
#endregion

#region reverse
/*
 * array icerisinde elementleri tersine siralayir
 */
//Array names = new[] { "Resad", "Ferid", "Kamran", "Zaur", "Elcan", "Avaz" };

//Array.Reverse(names);

#endregion

#region sort
/*
 * siralama isini gorur
 *  arrayindaxilindeki elementlerin tipine uygun olaraq siralama emelyyati yerine yetirir.
 */ //3,4,5,1
//Array names = new[] { "Resad", "Ferid", "Kamran", "Zaur", "Elcan", "Avaz" };
//Array.Sort(names);

#endregion

#region createInstance

//int[] values = new int[3];

//Array valuesArray = Array.CreateInstance(typeof(int),3);

#endregion

#endregion

#region properties / ozellikler

#region IsReadOnly



#endregion

#region IsFixedSize



#endregion

#region Length



#endregion

#region Rank

/*
 * arrayin derecesini nece multidimensional
 *
 */

#endregion

#endregion
#endregion

#region c# 8.0 ranges  and indices // System.Ranges - System.Index opearator .. ^
/*
 * index tipi arrayler ve collectionlardaki elementin indexini saxlamaqdadir.
 * ^ operator tersine istifade edilerse normal arraylerde
 * 0-dan baslayib n-1 bire gedirdise burada 1-den baslayib n- gedir
 */

//string[] names = { "a", "b", "c" };
//Index index = 2; // "c"

//Index index2 = ^2; // "b"

#region range System.Range
/*
 * deyer araligi vererek istifade edilir.
 */
//int[] numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

//Range range = 3..7; // 3 indexdir ; 7 ise siradir
//Range range1 = ^3..7; // 3 indexdir ; 7 ise siradir


//Range range = ..; // kopyalama ucun bele istifade edile biler

//var numbers2 = numbers[range];
#endregion
#endregion

#region example

#region 1.

/*
 * int tipinde bir array yaradin, hemin arrayin nece elementden
 * ibaret olacagini istifadeci daxil etsin, bundan sonra hemin arrayin
 * elementlerinin deyerlerini daxil edir, netice olaraq arrayin daxilindeki
 * elementlerin tek-tek deyerlerini, cemini ve oratalamasini cap edin.
 */

//Console.Write("array ucun elemet sayini daxil edin :\t");

//int arrLength = Convert.ToInt32(Console.ReadLine());

//int[] arr = new int[arrLength];

//for (int i = 0; i < arrLength; i++)
//{
//    Console.Write("Index {0}: elementinin deyeri\t",i);
//    arr[i] = Convert.ToInt32(Console.ReadLine());
//}

//Console.WriteLine("++++++++");
//int total=0, average = 0;

//foreach (var number in arr)
//{
//    Console.WriteLine(number);
//    total += number;
//}

//average = total / arrLength;
//Console.WriteLine("Total:\t{0} ,\n average:\t{1}" ,total,average);
#endregion

#region 2. random
/*
 * 20 elementden ibaret olan bir array yaradin.
 * Arrayin elementlerin deyerlerini Random classinin next funksiyasi ile
 * 1-10 arasinda deyerler ile doldurun. Elementlerini ekrana cap etdikden sonra,
 * array icerisinde nece eded 4 oldugunu tapin.
 */
//int[] numbers = new int[20];
//Random random = new Random();

//for (int i = 0; i < numbers.Length; i++)
//{
//    numbers[i] = random.Next(1, 10);
//}

//int count = 0;

//foreach (var item in numbers)
//{
//    Console.WriteLine(item);

//    if (item is 4)
//        count++;
//}

//Console.WriteLine("++++++++++++");

//if( count is 0)
//    Console.WriteLine("4 ededi arrayde yoxdur");
//else
//    Console.WriteLine(" arraydeki 4lerin sayi {0}",count);
#endregion

#endregion

#endregion

#region multidimensional

/*
 *  Multidimensional array daha cox oyun programlasdirmasinda,
 *  statistika ile bagli islerde istifade edilmektedir.
 *
 * Bu arraylerde indexer icerisindeki vergul sayi + 1 ile arrayin
 * nece dereceli oldugunu basa duse bilerik [,,,] 4 dereceli
 */

//int[,] numbers = new int[3, 5];
//int[,] numbers =
//{
//    {1,2,3},
//    {4,5,6,7,8 }
//};


//int[,,,] numbers =
//{
//    {
//        {
//            {0,1,2 }
//        }
//    }
//};
#region deyer verilmesi

//int[,] numbers = new int[3, 4];

//numbers[0, 0] = 10;
#endregion

#region loop


//int[,,] numbers = new int[2,2 ,4];
//numbers[0, 0, 0] = 1;
//numbers[0, 0, 1] = 2;
//numbers[0, 0, 2] = 3;
//numbers[0, 0, 3] = 4;

//int[,,] arr3d3 = new int[2, 2, 3]{
//    { { 1, 2, 3}, {4, 5, 6} },
//    { { 7, 8, 9}, {10, 11, 12} }
//};
//for (int i = 0; i < arr3d3.GetLength(0); i++)
//{
//    for (int j = 0; j < arr3d3.GetLength(1); j++)
//    {
//        for (int k = 0; k < arr3d3.GetLength(2); k++)
//        {
//            Console.Write("{0}\t", arr3d3[i,j,k]);
//        }

//        Console.WriteLine("");
//    }
//}
#endregion
#endregion

#region C# Jagged Arrays: An Array of Array

/*
 * Array icerisinde array....
 * Multidimensional arraylerden ferqi sutun sayinin sabit olmamasidir.
 */
//int[][] jArray1 = new int[2][]; // can include two single-dimensional arrays 
//int[][,] jArray2 = new int[3][,]; // can include three two-dimensional arrays 

#endregion




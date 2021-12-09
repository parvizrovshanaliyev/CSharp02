#Asynchronous Programming

![thread](https://user-images.githubusercontent.com/44087592/145332099-b4c689ca-7831-4fbb-af12-ba9455de9faf.png)


#Single Thread vs MultiThreading
- Process :
- Isleyen programlara process deyilir. word , excel ve sair. Process her zaman tek bir main thread ile baslayir.
- Bir process oz icerisinde de basqa bir process yarada bilmekdedir buna child process deyilir.

- Thread :
 
- Bir process-in bir ve daha artiq isi eyni vaxtda islemesini temin eden mexanizme  deyilir ,
- emeliyyat sistemi seviyyesinde heyata kecirilen her hansisa bir is / process-den basqa bir sey deyil .
- bir process daxilinde bir ve ya daha artiq thread ola bilmekdedir , thread eyni vaxta bir is gorur, n eded
- tread n qeder is mentiqi ile baxa bilerik.
- Thread -ler hem de light-weight process olaraqda bilinmekdedir.
- Multi-threading : 
- Bir process icerisinde birden artiq thread isleye bilmesine deyilir.
- Parallel programming : 
- Thread ler cox nuveli (core) prosessorlarda ferqli nuvelerde eyni vaxtda isledile biler  bu yanasma
- parallel programming dir.
- 

Process vs Thread
- Thread processin mueyyen bir segmentine aid edilir.
- Bir thread in yaradilmasi ve istifadesi processe nisbeten daha tez basa gelir.
- Processler bir birinden izolasiya olunmush sekilde isleyir lakin , thread ler eyni ram reasource dan istifade edirler.
- Process-ler thread-e gore daha artiq resource xercleyir.
- Bir processs bloknaarsa diger process-ler onu gozleyir , threadlerde bele deyil  isine davam edir.

<br>
Paralellism: 
birden artiq cpu ya da core-da (cpu core / nuve) eyni  vaxtda  emeliyyat aparilmasi menasini verir.
<br>
Concurrency :
tek bir process uzerinde eyni vaxtda birden artiq emeliyyatin yerine yetirilmesi menasini verir.
<br>
User Thread , Kernel Thread :
User Thread istifadeci terefinden yaradilir , java ve  .net -de thread classi vasitesile user thread yaradila biler.
CPU -da sadece kernel thread istifade edile bildiyine gore her bir user thread-de ozluyunde kernel thread ile birlikde isleyir.

*User thread istifadeci terefinden Thread library-den istifade ederek idare olunur ,
Kernel tthread ise emeliyyeat sistemi terefinden idare edilir.
*Emeliyyat sistem user thread ile elaqeli her hansisa configuration elemir , idaresine qarismir.
*User threadlerin implementasiyasi kernel-e gore daha asandir.
*User threadlerde bir thread sistem requestlerini bloklasa butun process bloklanir , kernel thread-de 
ise bit thread bloklansa bele process daxilinde diger threadler isine davam edir 

https://youtu.be/mRISF16ao-0

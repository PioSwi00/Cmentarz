# Cmentarz
<img src="https://64.media.tumblr.com/31993c4ac659876389c890ca15869f9d/tumblr_pzl96p8Qcn1y7ei2ho1_1280.gif"></img>

<h2> Kilka zdan o naszym projekcie 😊</h2>
Oto nasz projekt Cmentarza, który z pewnością zainteresuje zywych i tych niekoniecznie 

W projekcie znajdziecie bazę danych cmentarza, gdzie można zarządzać grobowcami, zmarłymi, odwiedzającymi, właścicielami i użytkownikami. A wszystko to w jednym miejscu - jak w prawdziwym życiu!
 interfejs aplikacji zostanie zaprojektowany tak, aby wyglądał jak cmentarz 

Dla fanów SOLID - zaimplementowaliśmy Unit of Work, Repository Pattern oraz Dependency Injection. Dla tych którzy nie wiedzą co to jest, polecam Google.

Wszystko to działa na platformie .NET Core i Entity Framework, więc możecie być spokojni o wydajność i skalowalność.

Ciesz się wirtualnym cmentarzem bez wychodzenia z domu!

# Opis:
<h2>Użytkownicy występujący w systemie: </h2>
<img src="https://static.wikia.nocookie.net/minecraft_pl_gamepedia/images/c/c6/Ghast.gif/revision/latest?cb=20220505154127"></img>
<ul>
  <li><h3>Właściciel:</h3>
    <ul>
      <li>Posiada grobowce</li>
      <li>Możliwość przeglądania swoich grobowców</li>
      <li>Możliwość przeglądania zmarłych w swoich grobowcach</li>
      <li>Możliwość zakupienia grobowców</li>
      <li>Możliwość logowania na stronę</li>
    </ul>
  </li>
  <li><h3>Odwiedzający:<h3>
    <ul>
      <li>Możliwość przeglądania ofert grobowców</li>
      <li>Możliwość logowania na stronę</li>
      <li>Możliwość przeglądania grobowców</li>
    </ul>
  </li>
</ul>

# Diagram

![diagram](https://user-images.githubusercontent.com/72618700/228902776-b01144bc-26eb-498e-8a0a-dfe914d44601.png)

# Specyfikacja Systemu
<h2>Encje:</h2>

<ul>
  <li>Grobowiec:
    <ul>
      <li>Numer grobowca</li>
      <li>Numer właściciela</li>
      <li>Lokalizacja grobowca</li>
      <li>Cena grobowca</li>
      <li>Listę odwiedzających</li>
      <li>Informacje o tym, czy grobowiec jest już zajęty</li>
    </ul>
  </li>
  <li>Zmarły:
    <ul>
      <li>Numer zmarłego</li>
      <li>Imię</li>
      <li>Nazwisko</li>
      <li>Data urodzenia</li>
      <li>Data zgonu</li>
    </ul>
  </li>
  <li>Odwiedzający:
    <ul>
      <li>Numer odwiedzającego</li>
      <li>Imię</li>
      <li>Nazwisko</li>
    </ul>
  </li>
  <li>Użytkownik:
    <ul>
      <li>Numer użytkownika</li>
      <li>Login</li>
      <li>Hasło</li>
    </ul>
  </li>
  <li>Właściciel:
    <ul>
      <li>Numer właściciela</li>
      <li>Imię</li>
      <li>Nazwisko</li>
      <li>Adres zamieszkania</li>
      <li>Informacje o ilości posiadanych grobowców</li>
    </ul>
  </li>
</ul>
<h2>Związki pomiędzy encjami:</h2>

<ul>
  <li>Związek 1:n pomiędzy encją Grobowiec a encją Zmarły:
    <ul>
      <li>Jeden grobowiec może zawierać wiele zmarłych, ale każdy zmarły może być pochowany tylko w jednym grobowcu.</li>
    </ul>
  </li>
  <li>Związek 1:n pomiędzy encją Grobowiec a encją Właściciel:
    <ul>
      <li>Jeden właściciel może posiadać wiele grobowców, ale każdy grobowiec może posiadać tylko jednego właściciela.</li>
    </ul>
  </li>
  <li>Związek n:m pomiędzy encją Grobowiec a encją Odwiedzający:
    <ul>
      <li>Wiele osób może odwiedzać jeden grobowiec, ale jedna osoba może odwiedzać wiele grobowców.</li>
    </ul>
  </li>
  <li>Związek 1:1 pomiędzy encją Użytkownik a encją Właściciel oraz pomiędzy Użytkownikiem a Odwiedzającym:
    <ul>
      <li>Każdy użytkownik może być albo właścicielem albo odwiedzającym.</li>
    </ul>
  </li>
</ul>
<h2>Dodane Funkcjonalosci<h2>
<ul>
 <li>
  Sortowanie zmarłych
 </li>
 <li>
  Wyszukiwanie zmarlych w przedziale (data urodzenia,smierci)
 </li>
 <li>
  Wyszukanie Grobów
 </li>
 <li>
  Kupowanie Grobów
 </li>
 <li>
  Logowanie
 </li>
 <li>
 Wyszukiwanie Odwiedzajacych po Nazwisku i sortowanie po imieniu
 </li>
 <li> 
 Sortowanie Wlascicieli 
 </li>
 </ul>

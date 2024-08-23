# Frontend-uppgift

#### Omegapoint Göteborg

Syftet med uppgiften är inte att den ska vara tekniskt utmanande, utan snarare att ge oss en inblick i din problemlösnings-förmåga. Det vi kommer att bedöma när vi granskar din lösning är:

- Struktur och arkitektur
- Läsbarhet
- Underhållbarhet

## Redovisning
När du har färdigställt uppgiften skall en länk till `GitHub`, `Dropbox`, `Google Drive` eller liknande mailas saman.movaghar@omegapoint.se. Vid senare redovisningstillfälle får du presentera din lösning och motivera de val du gjort varpå vi tillsammans tittar på din lösning och diskuterar kring den.

## Teknik
**Frontend**: För att lösa uppgiften ser vi helst att du väljer React och TypeScript. Användning av UI-bibliotek är valfritt och vi ser helst att gränssnittet är användarvänligt hellre än att det har snygg design. Vi vill också att du inkluderar en enklare dokumentation (i form av `README.MD`) som förklarar hur man kör applikationen bland annat

**API**: Använd [The Movie Database (TMDb) API](https://developer.themoviedb.org/) för att göra uppslag.

## Kravspecifikation

Din uppgift är att skapa en webb-applikation där användaren kan söka i en filmdatabas där man t.ex. kan se en films titel, poster, genre och handling.

- Applikationen skall ha ett användargränssnitt (enkelt eller utförligt)
- Applikationen skall kommunicera mellan klient och server (API)
- Användaren skall kunna söka med
    - Filmtitel
    - Utgivningsår
- Applikationen ska en navigering som leder till en detalj sida för filmen man klickar på
  och sidan ska visa
    - Filmtitel
    - Utgivningsår
    - Valfri extra information
- Applikationen skall minst visa upp
    - Filmposter
    - Filmtitel
- Laddningsindikator
    - När en användare initierar en sökning, bör en tydlig laddningsindikator visas för att signalera att data hämtas. Detta förbättrar användarupplevelsen genom att ge feedback om att systemet arbetar med förfrågan.
- Felhantering:Applikationen:
    - Applikationen ska hantera och informera användaren om eventuella fel som
      uppstår under datahämtning (t.ex. nätverksfel eller problem med API:et). En användarvänlig felmeddelande bör visas, som exempelvis "Ett fel uppstod när filmer skulle hämtas. Försök igen senare.
- Hantering av inga matchningar:
    - Om sökningen inte ger några träffar, visa det på lämpligt vis.
- Testning:
    - Skriv enhets- eller integrationstester för något enkelt fall

## Förslag på frivilliga/avancerade funktioner:
- Paginering:
    - För att hantera visningen av stora mängder filminformation effektivt och
      förbättra användarupplevelsen genom att dela upp data i hanterbara sidor.
- Funktionalitet för att spara favoritfilmer.

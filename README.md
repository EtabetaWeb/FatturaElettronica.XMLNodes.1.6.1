![FatturaElettronica.XMLNodes](https://etabetaweb.files.wordpress.com/2018/11/fattura-elettronica.jpg)


# Fattura Elettronica XMLNodes versione 1.6.1

**La versione 1.6.1 della libreria FatturaElettronica.XMLNodes è stata deprecata a favore della versione 1.7.1 (sviluppata in C# .NET Standard 2.0). Il codice open source viene comunque mantenuto on line con la finalità di studio e retrocompatibilità con le applicazioni che ne fanno ancora uso.**

------

Il progetto nasce dall’esigenza di creare una **libreria** che permetta di rappresentare tutti i **nodi previsti nel formato XML** (eXtensible Markup Language) della **Fattura Elettronica**. Basata sulla **versione 1.6.1** delle specifiche tecniche  dell’**Agenzia delle Entrate**, la **libreria** è sviluppata in **C# e NET Standard 2.0**.



# Organizzazione del repository

- **AppCode**: file sorgenti della libreria;

- **AppIcon**: file di icona;

- **CodiceEsempio**: file con il codice di esempio di un'applicazione per l'utilizzo della libreria in versione C# e Visual Basic;

- **Documentazione**: file di specifiche tecniche, rappresentazione tabellare ed elenco errori SDI;

  

# Note al codice di esempio

La soluzione comprende un esempio per utilizzare, tramite code-behind, i metodi e le proprietà della libreria.

**Il codice di esempio non è esaustivo, in quanto non utilizza tutti i metodi della libreria. Si prega di fare riferimento alle specifiche tecniche dell'Agenzia delle Entrate per l'elenco completo dei nodi previsti**.

Il codice principale si trova nella funzione GeneraXML e i parametri sono passati direttamente da codice ma possono essere passati anche tramite campi TextBox con le opportune modifiche.

La classe prevede due metodi principali "FatturaHeader" e "FatturaBoody". Questi sono i due nodi principali del file XML che racchiudono tutti i nodi figlio contenenti le informazioni previste dalla fattura elettronica.

**Dal codice di esempio è possibile comprendere come**:

- aggiungere un nodo con occorrenza singola;
- assegnare il valore alla proprietà di un nodo con occorrenza singola;
- assegnare il nodo figlio al nodo padre;
- aggiungere un nodo con occorrenza multipla;
- assegnazione delle proprietà al nodo con occorrenza multipla;

Inoltre, il codice serializza il file XML e lo salva sul computer.



# Installazione come package NuGet

FatturaElettronica.XMLNodes può essere scaricato anche come package [NuGet](https://www.nuget.org/packages/FatturaElettronica.XMLNodes/1.6.1). 

Per installarlo è sufficiente utilizzare il seguente comando tramite il Package Manager (sostituire le x con il valore appropriato della versione richiesta).

```c#
PM> Install-Package FatturaElettronica.XMLNodes -Version 1.x.x
```

Oppure, da riga di comando (CMD), con .NET Core:

```c#
dotnet add package FatturaElettronica.XMLNodes
```

Oppure, dalla Console di Gestione Pacchetti in Visual Studio.



# Guida per l'utilizzo

![CopertinaGuida](https://etabetaweb.files.wordpress.com/2021/05/cover-fatturaelettronica.xmlnodes-v1.6.1.jpg?w=640)

In **esclusiva** sullo store **[Amazon](https://amzn.to/3u7Dg44)** ed in **formato digitale**, la **guida all'utilizzo della libreria** open source per la generazione della Fattura Elettronica.

**La guida si rivolge**, principalmente, agli **sviluppatori principianti** che desiderano utilizzare la libreria nei loro programmi. Sono contenuti i **commenti al codice di esempio** non altrimenti recuperabili dai sorgenti presenti nel repository di GitHub.

Vi sono anche **informazioni utili** che possono essere sfruttate da **utenti avanzati** che vogliono **approfondire alcune tematiche relative alla Fatturazione Elettronica**.

È importante che il lettore abbia **familiarità con lo sviluppo del software** e con i concetti base della **programmazione ad oggetti**.

**[[ACQUISTA ONLINE](https://amzn.to/3u7Dg44)]**




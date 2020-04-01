![FatturaElettronica.XMLNodes](https://etabetaweb.files.wordpress.com/2018/11/fattura-elettronica.jpg)


**STATO BUILD:** [![Build Status](https://dev.azure.com/etabetawebdev/FatturaElettronica.XMLNodes/_apis/build/status/EtabetaWeb.FatturaElettronica.XMLNodes?branchName=master)](https://dev.azure.com/etabetawebdev/FatturaElettronica.XMLNodes/_build/latest?definitionId=5&branchName=master) [[**VISUALIZZA DETTAGLI**](https://dev.azure.com/etabetawebdev/FatturaElettronica.XMLNodes)]


# Fattura Elettronica XMLNodes

Il progetto nasce dall’esigenza di creare una **libreria** che permetta di rappresentare tutti i **nodi previsti nel formato XML** (eXtensible Markup Language) della **Fattura Elettronica**. 

Basata sulla **versione 1.5** delle specifiche tecniche dell’**Agenzia delle Entrate**, la **libreria** è sviluppata in **C# e NET Standard 2.0**.



# Nota

Per seguire l'evoluzione delle varie specifiche tecniche rilasciate nel tempo dall'Agenzia delle Entrate, fare riferimento alla seguente tabella di branching:

- **Master**: basato sul documento "Allegato A - Specifiche Tecniche Versione 1.5";



# Organizzazione del repository

- **AppCode**: file sorgenti della libreria;
- **AppIcon**: file di icona;
- **CodiceEsempio**: file con il codice di esempio di un'applicazione per l'utilizzo della libreria in versione C# e Visual Basic;
- **Documentazione**: file di specifiche tecniche, rappresentazione tabellare ed elenco errori SDI;



# Guida per l'utilizzo

In **esclusiva** sullo store **[Amazon](https://amzn.to/2UVpaT1)** ed in formato digitale, è disponibile la guida all'utilizzo della **libreria** **open source** per la generazione della **Fattura Elettronica**.

**La guida si rivolge**, principalmente, agli **sviluppatori principianti** che desiderano utilizzare la libreria nei loro programmi. Sono contenuti i **commenti al codice di esempio** non altrimenti recuperabili dai sorgenti presenti nel repository di GitHub.

Vi sono anche **informazioni utili e collegamenti al sito dell'Agenzia delle Entrate** che possono essere sfruttate da **utenti avanzati** che vogliano approfondire alcune tematiche relative alla Fatturazione Elettronica.

È importante che il lettore abbia **familiarità con lo sviluppo del software** e con i concetti base della **programmazione ad oggetti**.

![CopertinaGuida](https://etabetaweb.files.wordpress.com/2020/03/guida-fattura-xmlnodes-v15.jpg?w=616) 

**[[ACQUISTA ONLINE](https://amzn.to/2UVpaT1)]**



# Installazione come package NuGet

FatturaElettronica.XMLNodes può essere scaricato anche come package [NuGet](https://www.nuget.org/packages/FatturaElettronica.XMLNodes/). 

Per installarlo è sufficiente utilizzare il seguente comando tramite il Package Manager (sostituire le x con il valore appropriato della versione richiesta).

```c#
PM> Install-Package FatturaElettronica.XMLNodes -Version 1.x.x
```

Oppure, da riga di comando (CMD), con .NET Core:

```c#
dotnet add package FatturaElettronica.XMLNodes
```

Oppure, dalla Console di Gestione Pacchetti in Visual Studio.



# Utilizzo della libreria

### Creazione dell'istanza della classe

```c#
    FatturaElettronicaXMLNodes _nodoPrincipale = new FatturaElettronicaXMLNodes();
```

### Aggiunta di un metodo con occorrenza singola

```c#
    IdTrasmittente _idTrasmittente = new IdTrasmittente();
```

### Assegnazione del valore ad una proprietà del metodo

```c#
    _idTrasmittente.IdPaese = "IT";
```

### Assegnazione del metodo figlio al metodo padre

```c#
    datiTrasmissione.IdTrasmittente = _idTrasmittente;
```

### Aggiunta di un metodo con occorrenza multipla

```c#
    DatiCassaPrevidenziale datiCassaPrevidenziale = new DatiCassaPrevidenziale();
    List<DatiCassaPrevidenziale> datiCassaPrevidenzialeList = new List<DatiCassaPrevidenziale>();
```

### Assegnazione delle proprietà al nodo con occorrenza multipla

```c#
    datiCassaPrevidenziale.TipoCassa = "";
    datiCassaPrevidenziale.AlCassa = "";
    [...]
    datiCassaPrevidenzialeList.Add(datiCassaPrevidenziale);
    datiGeneraliDocumento.DatiCassaPrevidenziale = datiCassaPrevidenzialeList;
```

### Serializzazione finale dei nodi

```c#
    XmlRootAttribute XmlRoot = new XmlRootAttribute();
    XmlRoot.Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.2";
    XmlAttributes myxmlAttribute = new XmlAttributes();
    myxmlAttribute.XmlRoot = XmlRoot;
    XmlAttributeOverrides xmlAttributeOverrides = new XmlAttributeOverrides();
    xmlAttributeOverrides.Add(typeof(FatturaElettronicaXMLNodes), myxmlAttribute);
    // esegue la pulizia degli appributi FatturaElettronicaHeader e FatturaElettronicaBody
    XmlAttributes emptyNsAttribute = new XmlAttributes();
    XmlElementAttribute xElement1 = new XmlElementAttribute();
    xElement1.Namespace = "";
    emptyNsAttribute.XmlElements.Add(xElement1);
    xmlAttributeOverrides.Add(typeof(FatturaElettronicaXMLNodes), "FatturaElettronicaHeader", emptyNsAttribute);
    xmlAttributeOverrides.Add(typeof(FatturaElettronicaXMLNodes), "FatturaElettronicaBody", emptyNsAttribute);
    // specifica la versione di trasmissione se verso PA o Privato
    nodoPrincipale.versione = "FPA12";
    // serializza i nodi ed esegue l'override del nodo principale per aggiungere il tag "pX"
    XmlSerializer ser = new XmlSerializer(nodoPrincipale.GetType(), xmlAttributeOverrides);
    ser = new XmlSerializer(nodoPrincipale.GetType(), new XmlRootAttribute("pX"));
    // aggiunge gli attributi
    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    ns.Add("ds", "http://www.w3.org/2000/09/xmldsig#");
    ns.Add("p", "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2");
    ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
    var path = percorso + nome_file;
    System.IO.FileStream file = System.IO.File.Create(path);
    ser.Serialize(new System.IO.StreamWriter(file, new System.Text.UTF8Encoding()), nodoPrincipale, ns);
    file.Close();
```



# Note al codice di esempio

La soluzione comprende un esempio per utilizzare, tramite code-behind, i metodi e le proprietà della libreria.

**Il codice dei esempio non è esaustivo, in quanto non utilizza tutti i metodi della classe, e vi rimando alle specifiche tecniche dell'Agenzia delle Entrate per l'elenco completo dei nodi previsti**.

Il codice principale si trova nella funzione GeneraXML e i parametri sono passati direttamente da codice ma possono essere passati anche tramite campi TextBox con le opportune modifiche.

La classe prevede due metodi principali "FatturaHeader" e "FatturaBoody". Questi sono i due nodi principali del file XML che racchiudono tutti i nodi figlio contenenti le informazioni previste dalla fattura elettronica.

**Dal codice di esempio è possibile comprendere come**:

- aggiungere un nodo con occorrenza singola;
- assegnare il valore alla proprietà di un nodo con occorrenza singola;
- assegnare il nodo figlio al nodo padre;
- aggiungere un nodo con occorrenza multipla;
- assegnazione delle proprietà al nodo con occorrenza multipla;

Inoltre, il codice serializza il file XML e lo salva sul computer.
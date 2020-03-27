![FatturaElettronica.XMLNodes](https://etabetaweb.files.wordpress.com/2018/11/fattura-elettronica.jpg)


**STATO BUILD:** [![Build Status](https://dev.azure.com/etabetawebdev/FatturaElettronica.XMLNodes/_apis/build/status/EtabetaWeb.FatturaElettronica.XMLNodes?branchName=master)](https://dev.azure.com/etabetawebdev/FatturaElettronica.XMLNodes/_build/latest?definitionId=5&branchName=master) [[**VISUALIZZA DETTAGLI**](https://dev.azure.com/etabetawebdev/FatturaElettronica.XMLNodes)]


# FatturaElettronica.XMLNodes

Il progetto FatturaElettronica.XMLNodes nasce dall’esigenza di creare una libreria (scritta in C# .NET Standard 2.0) che permetta di rappresentare tutti i nodi previsti nel formato **XML** (eXtensible Markup Language) della **Fattura Elettronica** basato sulle specifiche tecniche dell’Agenzia delle Entrate. 



# Nota

Per seguire l'evoluzione delle varie specifiche tecniche rilasciate nel tempo dall'Agenzia delle Entrate, fare riferimento alla seguente tabella di branching:

- **Master**: basato sul documento "Allegato A - Specifiche Tecniche Versione 1.5";



# Guida per l'utilizzo

Sullo store di Amazon è disponibile anche la guida per l'utilizzo come libreria NuGet. La guida si rivolge, in particolar modo, agli sviluppatori principianti che desiderano utilizzarla nei loro programmi. Nella guida sono contenuti i commenti al codice di esempio non altrimenti recuperabili dai sorgenti presenti nel repository di GitHub.

![CopertinaGuida](https://etabetaweb.files.wordpress.com/2020/03/copertina-guida-fattura-elettronica-xml-nodes.jpg) 

[ACQUISTA ONLINE](https://amzn.to/2wKFdLl)



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

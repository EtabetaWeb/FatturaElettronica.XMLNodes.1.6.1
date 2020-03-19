using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WinFormCShap
{
    public partial class GeneraXML : Form
    {
        public GeneraXML()
        {
            InitializeComponent();
        }

        private void BtnEseguiCodice_Click(object sender, EventArgs e)
        {
            string dir;
            string nomeFile;
            dir = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";
            nomeFile = "EsempioFileFatturaElettronica.xml";
            TxtPercorsoFile.Text = dir + nomeFile;
            if (genera_xml(dir, nomeFile) == false)
            {
                BtnEseguiCodice.Enabled = false;
                BtnEseguiCodice.Text = "ATTENZIONE: si è verificato un errore!";
            }
            else
            {
                BtnEseguiCodice.Enabled = false;
                BtnEseguiCodice.Text = "Il file è stato generato correttamente!";
            }
        }

        private bool genera_xml(string percorso, string nome_file)
        {
            bool esito = false;
            try
            {
                // istanzia la classe
                FatturaElettronicaXMLNodes nodoPrincipale = new FatturaElettronicaXMLNodes();
                // ------------------------------------------------------------------------------------------
                // 1 <FatturaElettronicaHeader>
                // ------------------------------------------------------------------------------------------
                FatturaElettronicaHeader overviewHeader = new FatturaElettronicaHeader();

                // ------------------------------------------------------------------------------------------
                // 1.1 <DatiTrasmissione>
                // ------------------------------------------------------------------------------------------
                DatiTrasmissione datiTrasmissione = new DatiTrasmissione();
                // 1.1.1 <IdTrasmittente>
                IdTrasmittente idTrasmittente_111 = new IdTrasmittente();
                idTrasmittente_111.IdPaese = "IT";
                idTrasmittente_111.IdCodice = "01234567890";
                datiTrasmissione.IdTrasmittente = idTrasmittente_111;
                // 1.1.2 <ProgressivoInvio>
                datiTrasmissione.ProgressivoInvio = "00001";
                // 1.1.3 <FormatoTrasmissione>
                // valori ammessi "FPA12"=fattura verso PA, "FPR12"=fattura verso privati
                datiTrasmissione.FormatoTrasmissione = "FPR12";
                // 1.1.4 <CodiceDestinatario>
                datiTrasmissione.CodiceDestinatario = "ABC1234";
                // 1.1.5 <ContattiTrasmittente>
                ContattiTrasmittente contattiTrasmittente_115 = new ContattiTrasmittente();
                contattiTrasmittente_115.Telefono = "";
                contattiTrasmittente_115.Email = "";
                datiTrasmissione.ContattiTrasmittente = contattiTrasmittente_115;
                // 1.1.6 <PECDestinatario>
                datiTrasmissione.PECDestinatario = "";
                // CHIUDE IL NODO <DatiTrasmissione>
                overviewHeader.DatiTrasmissione = datiTrasmissione;

                // ------------------------------------------------------------------------------------------
                // 1.2 <CedentePrestatore>
                // ------------------------------------------------------------------------------------------
                CedentePrestatore cedentePrestatore = new CedentePrestatore();
                // 1.2.1 <DatiAnagrafici>
                DatiAnagrafici datiAnagrafici_121 = new DatiAnagrafici();
                // 1.2.1.1 <IdFiscaleIVA>
                IdFiscaleIVA idFiscaleIVA_121 = new IdFiscaleIVA();
                idFiscaleIVA_121.IdPaese = "IT";
                idFiscaleIVA_121.IdCodice = "01234567890";
                datiAnagrafici_121.IdFiscaleIVA = idFiscaleIVA_121;
                // 1.2.1.2 <CodiceFiscale>
                datiAnagrafici_121.CodiceFiscale = "";
                // 1.2.1.3 <Anagrafica>
                Anagrafica anagrafica_121 = new Anagrafica();
                anagrafica_121.Denominazione = "SOCIETA' ALPHA SRL";
                anagrafica_121.Nome = "";
                anagrafica_121.Cognome = "";
                anagrafica_121.Titolo = "";
                anagrafica_121.CodEORI = "";
                datiAnagrafici_121.Anagrafica = anagrafica_121;
                // 1.2.1.4 <AlboProfessionale>
                datiAnagrafici_121.AlboProfessionale = "";
                // 1.2.1.5 <ProvinciaAlbo>
                datiAnagrafici_121.ProvinciaAlbo = "";
                // 1.2.1.6 <NumeroIscrizioneAlbo>
                datiAnagrafici_121.NumeroIscrizioneAlbo = "";
                // 1.2.1.7 <DataIscrizioneAlbo>
                datiAnagrafici_121.DataIscrizioneAlbo = "";
                // 1.2.1.8 <RegimeFiscale>
                datiAnagrafici_121.RegimeFiscale = "RF19";
                cedentePrestatore.DatiAnagrafici = datiAnagrafici_121;
                // 1.2.2 <Sede>
                Sede sede_122 = new Sede();
                sede_122.Indirizzo = "VIALE ROMA";
                sede_122.NumeroCivico = "543";
                sede_122.CAP = "07100";
                sede_122.Comune = "SASSARI";
                sede_122.Provincia = "SS";
                sede_122.Nazione = "IT";
                cedentePrestatore.Sede = sede_122;
                // 1.2.3 <StabileOrganizzazione>
                StabileOrganizzazione stabileOrganizzazione_123 = new StabileOrganizzazione();
                stabileOrganizzazione_123.Indirizzo = "";
                stabileOrganizzazione_123.NumeroCivico = "";
                stabileOrganizzazione_123.CAP = "";
                stabileOrganizzazione_123.Comune = "";
                stabileOrganizzazione_123.Provincia = "";
                stabileOrganizzazione_123.Nazione = "";
                cedentePrestatore.StabileOrganizzazione = stabileOrganizzazione_123;
                // 1.2.4 <IscrizioneREA>
                IscrizioneREA iscrizioneREA_124 = new IscrizioneREA();
                iscrizioneREA_124.Ufficio = "";
                iscrizioneREA_124.NumeroREA = "";
                iscrizioneREA_124.CapitaleSociale = "";
                iscrizioneREA_124.SocioUnico = "";
                iscrizioneREA_124.StatoLiquidazione = "";
                cedentePrestatore.IscrizioneREA = iscrizioneREA_124;
                // 1.2.5 <Contatti>
                Contatti contatti_125 = new Contatti();
                contatti_125.Telefono = "";
                contatti_125.Fax = "";
                contatti_125.Email = "";
                cedentePrestatore.Contatti = contatti_125;
                cedentePrestatore.RiferimentoAmministrazione = "";
                // CHIUDE IL NODO <CedentePrestatore>
                overviewHeader.CedentePrestatore = cedentePrestatore;

                // ------------------------------------------------------------------------------------------
                // 1.3 <RappresentanteFiscale>
                // ------------------------------------------------------------------------------------------
                RappresentanteFiscale rappresentanteFiscale = new RappresentanteFiscale();
                // 1.3.1 <DatiAnagrafici>
                DatiAnagrafici datiAnagrafici_131 = new DatiAnagrafici();
                // 1.3.1.1 <IdFiscaleIVA>
                IdFiscaleIVA idFiscaleIVA_131 = new IdFiscaleIVA();
                idFiscaleIVA_131.IdPaese = "";
                idFiscaleIVA_131.IdPaese = "";
                datiAnagrafici_131.IdFiscaleIVA = idFiscaleIVA_131;
                // 1.3.1.2 <CodiceFiscale>
                datiAnagrafici_131.CodiceFiscale = "";
                // 1.3.1.3 <Anagrafica>
                Anagrafica anagrafica_131 = new Anagrafica();
                anagrafica_131.Denominazione = "";
                anagrafica_131.Nome = "";
                anagrafica_131.Cognome = "";
                anagrafica_131.Titolo = "";
                anagrafica_131.CodEORI = "";
                datiAnagrafici_131.Anagrafica = anagrafica_131;
                rappresentanteFiscale.DatiAnagrafici = datiAnagrafici_131;
                // CHIUDE IL NODO <RappresentanteFiscale>
                overviewHeader.RappresentanteFiscale = rappresentanteFiscale;

                // ------------------------------------------------------------------------------------------
                // 1.4 <CessionarioCommittente>
                // ------------------------------------------------------------------------------------------
                CessionarioCommittente cessionarioCommittente = new CessionarioCommittente();
                // 1.4.1 <DatiAnagrafici>
                DatiAnagrafici datiAnagrafici_141 = new DatiAnagrafici();
                // 1.4.1.1 <IdFiscaleIVA>
                IdFiscaleIVA idFiscaleIVA_141 = new IdFiscaleIVA();
                idFiscaleIVA_141.IdPaese = "";
                idFiscaleIVA_141.IdCodice = "";
                datiAnagrafici_141.IdFiscaleIVA = idFiscaleIVA_141;
                // 1.4.1.2 <CodiceFiscale>
                datiAnagrafici_141.CodiceFiscale = "09876543210";
                // 1.4.1.3 <Anagrafica>
                Anagrafica anagrafica_141 = new Anagrafica();
                anagrafica_141.Denominazione = "AMMINISTRAZIONE BETA";
                anagrafica_141.Nome = "";
                anagrafica_141.Cognome = "";
                anagrafica_141.Titolo = "";
                anagrafica_141.CodEORI = "";
                datiAnagrafici_141.Anagrafica = anagrafica_141;
                cessionarioCommittente.DatiAnagrafici = datiAnagrafici_141;
                // 1.4.2 <Sede>
                Sede sede_142 = new Sede();
                sede_142.Indirizzo = "VIA TORINO";
                sede_142.NumeroCivico = "38";
                sede_142.CAP = "00145";
                sede_142.Comune = "ROMA";
                sede_142.Provincia = "RM";
                sede_142.Nazione = "IT";
                cessionarioCommittente.Sede = sede_142;
                // 1.4.3 <StabileOrganizzazione>
                StabileOrganizzazione stabileOrganiccazione_143 = new StabileOrganizzazione();
                stabileOrganiccazione_143.Indirizzo = "";
                stabileOrganiccazione_143.NumeroCivico = "";
                stabileOrganiccazione_143.CAP = "";
                stabileOrganiccazione_143.Comune = "";
                stabileOrganiccazione_143.Provincia = "";
                stabileOrganiccazione_143.Nazione = "";
                cessionarioCommittente.StabileOrganizzazione = stabileOrganiccazione_143;
                // 1.4.4 <RappresentanteFiscale>
                RappresentanteFiscale rappresentanteFiscale_144 = new RappresentanteFiscale();
                DatiAnagrafici datiAnagrafici_144 = new DatiAnagrafici();
                // 1.4.4.1 <IdFiscaleIVA>
                IdFiscaleIVA idFiscaleIVA_144 = new IdFiscaleIVA();
                idFiscaleIVA_144.IdPaese = "";
                idFiscaleIVA_144.IdCodice = "";
                datiAnagrafici_144.IdFiscaleIVA = idFiscaleIVA_144;
                Anagrafica anagrafica_144 = new Anagrafica();
                anagrafica_144.Denominazione = "";
                anagrafica_144.Nome = "";
                anagrafica_144.Cognome = "";
                datiAnagrafici_144.Anagrafica = anagrafica_144;
                rappresentanteFiscale_144.DatiAnagrafici = datiAnagrafici_144;
                // CHIUDE IL NODO <CessionarioCommittente>
                overviewHeader.CessionarioCommittente = cessionarioCommittente;

                // ------------------------------------------------------------------------------------------
                // 1.5 <TerzoIntermediarioOSoggettoEmittente>
                // ------------------------------------------------------------------------------------------
                TerzoIntermediarioOSoggettoEmittente terzoIntermediarioOSoggettoEmittente = new TerzoIntermediarioOSoggettoEmittente();
                // 1.5.1 <DatiAnagrafici>
                DatiAnagrafici datiAnagrafici_151 = new DatiAnagrafici();
                // 1.5.1.1 <IdFiscaleIVA>
                IdFiscaleIVA idFiscaleIVA_151 = new IdFiscaleIVA();
                idFiscaleIVA_151.IdPaese = "";
                idFiscaleIVA_151.IdCodice = "";
                datiAnagrafici_151.IdFiscaleIVA = idFiscaleIVA_151;
                // 1.5.1.2 <CodiceFiscale>
                datiAnagrafici_151.CodiceFiscale = "";
                // 1.5.1.2 <CodiceFiscale>
                datiAnagrafici_151.CodiceFiscale = "";
                // 1.5.1.3 <Anagrafica>
                Anagrafica anagrafica_151 = new Anagrafica();
                anagrafica_151.Denominazione = "";
                anagrafica_151.Nome = "";
                anagrafica_151.Cognome = "";
                anagrafica_151.Titolo = "";
                anagrafica_151.CodEORI = "";
                datiAnagrafici_151.Anagrafica = anagrafica_151;
                // CHIUDE IL NODO <TerzoIntermediarioOSoggettoEmittente>
                overviewHeader.TerzoIntermediarioOSoggettoEmittente = terzoIntermediarioOSoggettoEmittente;
                // ------------------------------------------------------------------------------------------
                // 1.6 <SoggettoEmittente>
                // ------------------------------------------------------------------------------------------
                overviewHeader.SoggettoEmittente = "";

                // ------------------------------------------------------------------------------------------
                // 2 <FatturaElettronicaBody>
                // ------------------------------------------------------------------------------------------
                FatturaElettronicaBody overviewBody = new FatturaElettronicaBody();

                // ------------------------------------------------------------------------------------------
                // 2.1 <DatiGenerali>
                // ------------------------------------------------------------------------------------------
                DatiGenerali datiGenerali = new DatiGenerali();
                // ------------------------------------------------------------------------------------------
                // 2.1.1 <DatiGeneraliDocumento>
                // ------------------------------------------------------------------------------------------
                DatiGeneraliDocumento datiGeneraliDocumento = new DatiGeneraliDocumento();
                datiGeneraliDocumento.TipoDocumento = "TD01";
                datiGeneraliDocumento.Divisa = "EUR";
                datiGeneraliDocumento.Data = "2017-01-18";
                datiGeneraliDocumento.Numero = "123";
                DatiRitenuta datiRitenuta = new DatiRitenuta();
                datiRitenuta.TipoRitenuta = "";
                datiRitenuta.ImportoRitenuta = "";
                datiRitenuta.AliquotaRitenuta = "";
                datiRitenuta.CausalePagamento = "";
                datiGeneraliDocumento.DatiRitenuta = datiRitenuta;
                DatiBollo datiBollo = new DatiBollo();
                datiBollo.BolloVirtuale = "";
                datiBollo.ImportoBollo = "";
                datiGeneraliDocumento.DatiBollo = datiBollo;
                DatiCassaPrevidenziale datiCassaPrevidenziale = new DatiCassaPrevidenziale();
                List<DatiCassaPrevidenziale> datiCassaPrevidenzialeList = new List<DatiCassaPrevidenziale>();
                datiCassaPrevidenziale.TipoCassa = "";
                datiCassaPrevidenziale.AlCassa = "";
                datiCassaPrevidenziale.ImportoContributoCassa = "";
                datiCassaPrevidenziale.ImponibileCassa = "";
                datiCassaPrevidenziale.AliquotaIVA = "";
                datiCassaPrevidenziale.Ritenuta = "";
                datiCassaPrevidenziale.Natura = "";
                datiCassaPrevidenziale.RiferimentoAmministrazione = "";
                datiCassaPrevidenzialeList.Add(datiCassaPrevidenziale);
                datiGeneraliDocumento.DatiCassaPrevidenziale = datiCassaPrevidenzialeList;
                ScontoMaggiorazione scontoMaggiorazione = new ScontoMaggiorazione();
                List<ScontoMaggiorazione> scontoMaggiorazioneList = new List<ScontoMaggiorazione>();
                scontoMaggiorazione.Tipo = "";
                scontoMaggiorazione.Percentuale = "";
                scontoMaggiorazione.Importo = "";
                scontoMaggiorazioneList.Add(scontoMaggiorazione);
                datiGeneraliDocumento.ScontoMaggiorazione = scontoMaggiorazioneList;
                datiGeneraliDocumento.ImportoTotaleDocumento = "";
                datiGeneraliDocumento.Arrotondamento = "";
                datiGeneraliDocumento.Causale = "";
                datiGeneraliDocumento.Art73 = "";
                datiGenerali.DatiGeneraliDocumento = datiGeneraliDocumento;
                // ------------------------------------------------------------------------------------------
                // 2.1.2 <DatiOrdineAcquisto> (list)
                // ------------------------------------------------------------------------------------------
                DatiOrdineAcquisto datiOrdineAcquisto = new DatiOrdineAcquisto();
                List<DatiOrdineAcquisto> datiOrdineAcquistoList = new List<DatiOrdineAcquisto>();
                datiOrdineAcquisto.RiferimentoNumeroLinea = "1";
                datiOrdineAcquisto.IdDocumento = "66685";
                datiOrdineAcquisto.Data = "2016-09-0";
                datiOrdineAcquisto.NumItem = "";
                datiOrdineAcquisto.CodiceCommessaConvenzione = "";
                datiOrdineAcquisto.CodiceCUP = "";
                datiOrdineAcquisto.CodiceCIG = "";
                datiOrdineAcquistoList.Add(datiOrdineAcquisto);
                datiGenerali.DatiOrdineAcquisto = datiOrdineAcquistoList;
                // ------------------------------------------------------------------------------------------
                // 2.1.3 <DatiContratto> (list)
                // ------------------------------------------------------------------------------------------
                DatiContratto datiContratto = new DatiContratto();
                List<DatiContratto> datiContrattoList = new List<DatiContratto>();
                datiContratto.RiferimentoNumeroLinea = "";
                datiContratto.IdDocumento = "";
                datiContratto.Data = "";
                datiContratto.NumItem = "";
                datiContratto.CodiceCommessaConvenzione = "";
                datiContratto.CodiceCUP = "";
                datiContratto.CodiceCIG = "";
                datiContrattoList.Add(datiContratto);
                datiGenerali.DatiContratto = datiContrattoList;
                // ------------------------------------------------------------------------------------------
                // 2.1.4 <DatiConvenzione> (list)
                // ------------------------------------------------------------------------------------------
                DatiConvenzione datiConvenzione = new DatiConvenzione();
                List<DatiConvenzione> datiConvenzioneList = new List<DatiConvenzione>();
                datiConvenzione.RiferimentoNumeroLinea = "";
                datiConvenzione.IdDocumento = "";
                datiConvenzione.Data = "";
                datiConvenzione.NumItem = "";
                datiConvenzione.CodiceCommessaConvenzione = "";
                datiConvenzione.CodiceCUP = "";
                datiConvenzione.CodiceCIG = "";
                datiConvenzioneList.Add(datiConvenzione);
                datiGenerali.DatiConvenzione = datiConvenzioneList;
                // ------------------------------------------------------------------------------------------
                // 2.1.5 <DatiRicezione> (list)
                // ------------------------------------------------------------------------------------------
                DatiRicezione datiRicezione = new DatiRicezione();
                List<DatiRicezione> datiRicezioneList = new List<DatiRicezione>();
                datiRicezione.RiferimentoNumeroLinea = "";
                datiRicezione.IdDocumento = "";
                datiRicezione.Data = "";
                datiRicezione.NumItem = "";
                datiRicezione.CodiceCommessaConvenzione = "";
                datiRicezione.CodiceCUP = "";
                datiRicezione.CodiceCIG = "";
                datiRicezioneList.Add(datiRicezione);
                datiGenerali.DatiRicezione = datiRicezioneList;
                // ------------------------------------------------------------------------------------------
                // 2.1.6 <DatiFattureCollegate> (list)
                // ------------------------------------------------------------------------------------------
                DatiFattureCollegate datiFattureCollegate = new DatiFattureCollegate();
                List<DatiFattureCollegate> datiFattureCollegateList = new List<DatiFattureCollegate>();
                datiFattureCollegate.RiferimentoNumeroLinea = "";
                datiFattureCollegate.IdDocumento = "";
                datiFattureCollegate.Data = "";
                datiFattureCollegate.NumItem = "";
                datiFattureCollegate.CodiceCommessaConvenzione = "";
                datiFattureCollegate.CodiceCUP = "";
                datiFattureCollegate.CodiceCIG = "";
                datiFattureCollegateList.Add(datiFattureCollegate);
                datiGenerali.DatiFattureCollegate = datiFattureCollegateList;
                // ------------------------------------------------------------------------------------------
                // 2.1.7 <DatiSAL> (list)
                // ------------------------------------------------------------------------------------------
                DatiSAL datiSAL = new DatiSAL();
                List<DatiSAL> datiSALList = new List<DatiSAL>();
                datiSAL.RiferimentoFase = "";
                datiSALList.Add(datiSAL);
                datiGenerali.DatiSAL = datiSALList;
                // ------------------------------------------------------------------------------------------
                // 2.1.8 <DatiDDT> (list)
                // ------------------------------------------------------------------------------------------
                DatiDDT datiDDT = new DatiDDT();
                List<DatiDDT> datiDDTList = new List<DatiDDT>();
                datiDDT.NumeroDDT = "";
                datiDDT.DataDDT = "";
                datiDDT.RiferimentoNumeroLinea = "";
                datiDDTList.Add(datiDDT);
                datiGenerali.DatiDDT = datiDDTList;
                // ------------------------------------------------------------------------------------------
                // 2.1.9 <DatiTrasporto>
                // ------------------------------------------------------------------------------------------
                DatiTrasporto datiTrasporto = new DatiTrasporto();
                DatiAnagraficiVettore datiAnagraficiVettore = new DatiAnagraficiVettore();
                IdFiscaleIVA idFiscaleIva = new IdFiscaleIVA();
                idFiscaleIva.IdCodice = "";
                idFiscaleIva.IdPaese = "";
                datiAnagraficiVettore.IdFiscaleIVA = idFiscaleIva;
                datiAnagraficiVettore.CodiceFiscale = "";
                Anagrafica anagraficaVettore = new Anagrafica();
                anagraficaVettore.Denominazione = "";
                anagraficaVettore.Nome = "";
                anagraficaVettore.Cognome = "";
                anagraficaVettore.Titolo = "";
                anagraficaVettore.CodEORI = "";
                datiAnagraficiVettore.Anagrafica = anagraficaVettore;
                datiAnagraficiVettore.NumeroLicenzaGuida = "";
                datiTrasporto.MezzoTrasporto = "";
                datiTrasporto.CausaleTrasporto = "";
                datiTrasporto.NumeroColli = "";
                datiTrasporto.Descrizione = "";
                datiTrasporto.UnitaMisuraPeso = "";
                datiTrasporto.PesoLordo = "";
                datiTrasporto.PesoNetto = "";
                datiTrasporto.DataOraRitiro = "";
                datiTrasporto.DataInizioTrasporto = "";
                datiTrasporto.TipoResa = "";
                IndirizzoResa indirizzoResa = new IndirizzoResa();
                indirizzoResa.Indirizzo = "";
                indirizzoResa.NumeroCivico = "";
                indirizzoResa.CAP = "";
                indirizzoResa.Comune = "";
                indirizzoResa.Provincia = "";
                indirizzoResa.Nazione = "";
                datiTrasporto.IndirizzoResa = indirizzoResa;
                datiTrasporto.DataOraConsegna = "";
                datiGenerali.DatiTrasporto = datiTrasporto;
                // ------------------------------------------------------------------------------------------
                // 2.1.10 <FatturaPrincipale>
                // ------------------------------------------------------------------------------------------
                FatturaPrincipale fatturaPrincipale = new FatturaPrincipale();
                fatturaPrincipale.NumeroFatturaPrincipale = "";
                fatturaPrincipale.DataFatturaPrincipale = "";
                datiGenerali.FatturaPrincipale = fatturaPrincipale;
                // CHIUDE IL NODO <DATIGENERALI>
                // ------------------------------------------------------------------------------------------
                overviewBody.DatiGenerali = datiGenerali;

                // ------------------------------------------------------------------------------------------
                // 2.2 <DatiBeniServizi>
                // ------------------------------------------------------------------------------------------
                DatiBeniServizi datiBeniServizi = new DatiBeniServizi();
                // ------------------------------------------------------------------------------------------
                // 2.2.1 <DettaglioLinee> (list)
                // ------------------------------------------------------------------------------------------
                DettaglioLinee dettaglioLinee = new DettaglioLinee();
                List<DettaglioLinee> dettaglioLineeList = new List<DettaglioLinee>();
                dettaglioLinee.NumeroLinea = "";
                dettaglioLinee.TipoCessionePrestazione = "";
                CodiceArticolo codiceArticolo = new CodiceArticolo();
                codiceArticolo.CodiceTipo = "";
                codiceArticolo.CodiceValore = "";
                dettaglioLinee.CodiceArticolo = codiceArticolo;
                dettaglioLinee.Descrizione = "";
                dettaglioLinee.Quantita = "";
                dettaglioLinee.UnitaMisura = "";
                dettaglioLinee.DataInizioPeriodo = "";
                dettaglioLinee.DataFinePeriodo = "";
                dettaglioLinee.PrezzoUnitario = "";
                ScontoMaggiorazione scontoMaggiorazione_221 = new ScontoMaggiorazione();
                scontoMaggiorazione_221.Tipo = "";
                scontoMaggiorazione_221.Percentuale = "";
                scontoMaggiorazione_221.Importo = "";
                dettaglioLinee.ScontoMaggiorazione = scontoMaggiorazione_221;
                dettaglioLinee.PrezzoTotale = "";
                dettaglioLinee.AliquotaIVA = "";
                dettaglioLinee.Ritenuta = "";
                dettaglioLinee.Natura = "";
                dettaglioLinee.RiferimentoAmministrazione = "";
                AltriDatiGestionali altriDatiGestionali = new AltriDatiGestionali();
                altriDatiGestionali.TipoDato = "";
                altriDatiGestionali.RiferimentoTesto = "";
                altriDatiGestionali.RiferimentoNumero = "";
                altriDatiGestionali.RiferimentoData = "";
                dettaglioLinee.AltriDatiGestionali = altriDatiGestionali;
                dettaglioLineeList.Add(dettaglioLinee);
                datiBeniServizi.DettaglioLinee = dettaglioLineeList;

                // ------------------------------------------------------------------------------------------
                // 2.2.2 <DatiRiepilogo> (list)
                // ------------------------------------------------------------------------------------------
                DatiRiepilogo datiRiepilogo = new DatiRiepilogo();
                List<DatiRiepilogo> datiRiepilogoList = new List<DatiRiepilogo>();
                datiRiepilogo.AliquotaIVA = "";
                datiRiepilogo.Natura = "";
                datiRiepilogo.SpeseAccessorie = "";
                datiRiepilogo.Arrotondamento = "";
                datiRiepilogo.ImponibileImporto = "";
                datiRiepilogo.Imposta = "";
                datiRiepilogo.EsigibilitaIVA = "";
                datiRiepilogo.RiferimentoNormativo = "";
                datiRiepilogoList.Add(datiRiepilogo);
                datiBeniServizi.DatiRiepilogo = datiRiepilogoList;
                // CHIUDE IL NODO <DatiBeniServizi>
                // ------------------------------------------------------------------------------------------
                overviewBody.DatiBeniServizi = datiBeniServizi;

                // ------------------------------------------------------------------------------------------
                // 2.3 <DatiVeicoli>
                // ------------------------------------------------------------------------------------------
                DatiVeicoli datiVeicoli = new DatiVeicoli();
                datiVeicoli.Data = "";
                datiVeicoli.TotalePercorso = "";
                // CHIUDE IL NODO <DatiBeniServizi>
                // ------------------------------------------------------------------------------------------
                overviewBody.DatiVeicoli = datiVeicoli;

                // ------------------------------------------------------------------------------------------
                // 2.4 <DatiPagamento>
                // ------------------------------------------------------------------------------------------
                DatiPagamento datiPagamento = new DatiPagamento();
                datiPagamento.CondizioniPagamento = "";
                DettaglioPagamento dettaglioPagamento = new DettaglioPagamento();
                dettaglioPagamento.Beneficiario = "";
                dettaglioPagamento.ModalitaPagamento = "";
                dettaglioPagamento.DataRiferimentoTerminiPagamento = "";
                dettaglioPagamento.GiorniTerminiPagamento = "";
                dettaglioPagamento.DataScadenzaPagamento = "";
                dettaglioPagamento.ImportoPagamento = "";
                dettaglioPagamento.CodUfficioPostale = "";
                dettaglioPagamento.CognomeQuietanzante = "";
                dettaglioPagamento.NomeQuietanzante = "";
                dettaglioPagamento.CFQuietanzante = "";
                dettaglioPagamento.TitoloQuietanzante = "";
                dettaglioPagamento.IstitutoFinanziario = "";
                dettaglioPagamento.IBAN = "";
                dettaglioPagamento.ABI = "";
                dettaglioPagamento.CAB = "";
                dettaglioPagamento.BIC = "";
                dettaglioPagamento.ScontoPagamentoAnticipato = "";
                dettaglioPagamento.DataLimitePagamentoAnticipato = "";
                dettaglioPagamento.PenalitaPagamentiRitardati = "";
                dettaglioPagamento.DataDecorrenzaPenale = "";
                dettaglioPagamento.CodicePagamento = "";
                datiPagamento.DettaglioPagamento = dettaglioPagamento;
                // CHIUDE IL NODO <DatiPagamento>
                // ------------------------------------------------------------------------------------------
                overviewBody.DatiPagamento = datiPagamento;

                // ------------------------------------------------------------------------------------------
                // 2.5 <Allegati>
                // ------------------------------------------------------------------------------------------
                Allegati allegati = new Allegati();
                allegati.NomeAttachment = "";
                allegati.AlgoritmoCompressione = "";
                allegati.FormatoAttachment = "";
                allegati.DescrizioneAttachment = "";
                allegati.Attachment = "";
                // CHIUDE IL NODO <Allegati>
                // ------------------------------------------------------------------------------------------
                overviewBody.Allegati = allegati;
                // ------------------------------------------------------------------------------------------
                // Scrive XML
                // ------------------------------------------------------------------------------------------
                nodoPrincipale.FatturaElettronicaHeader = overviewHeader;
                nodoPrincipale.FatturaElettronicaBody = overviewBody;
                // SERIALIZZZA I NODI E SCRIVE L'XML
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
                // sostituisce il tag "pX" con il tag corretto "p:FatturaElettronica"
                string delimiterToBeReplaced = "pX";
                string newDelimiter = "p:FatturaElettronica";
                string contents = System.IO.File.ReadAllText(path);
                contents = contents.Replace(delimiterToBeReplaced, newDelimiter);
                System.IO.File.WriteAllText(path, contents);
                // ritorna esito positivo
                esito = true;
            }
            catch (Exception ex)
            {
                string eccezione = ex.ToString();
                return esito;
            }
            return esito;
        }

    }
}

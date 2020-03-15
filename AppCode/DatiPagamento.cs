using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

public class DatiPagamento
{

    /// <summary>
    ///     ''' Condizioni di pagamento
    ///     ''' TP01: pagamento a rate
    ///     ''' TP02: pagamento completo
    ///     ''' TP03: anticipo
    ///     ''' </summary>
    public string CondizioniPagamento;

    /// <summary>
    ///     ''' Dati di dettaglio del pagamento
    ///     ''' </summary>
    public DettaglioPagamento DettaglioPagamento;
}

using System;
using System.Xml;

namespace UFSTWSSecuritySample
{
    public class VirksomhedKalenderHentWriter : IPayloadWriter
    {
        public VirksomhedKalenderHentWriter(string SENummer, string SoegeDatoFraDate, string SoegeDatoTilDate)
        {
            seNummer = SENummer;
            soegeDatoFraDate = SoegeDatoFraDate;
            soegeDatoTilDate = SoegeDatoTilDate;
        }

        public void Write(XmlTextWriter writer)
        {
            var now = DateTime.UtcNow.ToString("o").Substring(0, 23) + "Z";
            var transactionId = Guid.NewGuid().ToString();
            string angivelseTypeNavn = "Moms";

            writer.WriteStartElement("urn", "VirksomhedKalenderHent_I", "urn:oio:skat:nemvirksomhed:ws:1.0.0");
            writer.WriteStartElement("ho", "HovedOplysninger", "http://rep.oio.dk/skat.dk/basis/kontekst/xml/schemas/2006/09/01/");
            writer.WriteStartElement("ho", "TransaktionIdentifikator", null);
            writer.WriteString(transactionId);
            writer.WriteEndElement(); // TransaktionIdentifikator
            writer.WriteStartElement("ho", "TransaktionTid", null);
            writer.WriteString(now);
            writer.WriteEndElement(); // TransaktionTid
            writer.WriteEndElement(); // HovedOplysninger
            writer.WriteStartElement("urn2", "VirksomhedSENummerIdentifikator", "http://rep.oio.dk/skat.dk/motor/class/virksomhed/xml/schemas/20080401/");
            writer.WriteString(seNummer);
            writer.WriteEndElement(); // VirksomhedSENummerIdentifikator
            writer.WriteStartElement("urn1", "AngivelseTypeNavn", "urn:oio:skat:nemvirksomhed:1.0.0");
            writer.WriteString(angivelseTypeNavn);
            writer.WriteEndElement(); // VirksomhedSENummerIdentifikator
            writer.WriteStartElement("urn", "AngivelseBetalingFristHentFra", null);
            writer.WriteStartElement("urn1", "SoegeDatoFraDate", "urn:oio:skat:nemvirksomhed:1.0.0");
            writer.WriteString(soegeDatoFraDate);
            writer.WriteEndElement(); // SoegeDatoFraDate
            writer.WriteStartElement("urn1", "SoegeDatoTilDate", "urn:oio:skat:nemvirksomhed:1.0.0");
            writer.WriteString(soegeDatoTilDate);
            writer.WriteEndElement(); // SoegeDatoTilDate
            writer.WriteEndElement(); // AngivelseBetalingFristHentFra
            writer.WriteEndElement(); // VirksomhedKalenderHent_I
        }

        private string seNummer;

        private string soegeDatoFraDate;

        private string soegeDatoTilDate;

    }
}

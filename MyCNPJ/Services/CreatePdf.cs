using MyCNPJ.Entities;
using MyCNPJ.Utils;
using System.Linq;
using System.Threading.Tasks;

namespace MyCNPJ.Services
{
    public class CreatePdf : ICreatePdf
    {
        /// <summary>
        /// Gera um Html simples para geração do PDF
        /// </summary>
        /// <param name="cnpjDataViewModel"></param>
        /// <returns></returns>
        public async Task<string> HtmlGenerateAsync(CnpjData cnpjDataViewModel)
        {
            string html = @"<html>
        <body style='margin-left: 50px;margin-right: 50px; margin-bottom: 50px;font-size: 9px; text-align: center;'>
        <br/>
            <h1>Dados da Empresa</h1>
            <br/>
            <div style='text-align: left;'>
                <label style='font-size: medium; font-weight: bold;'>Última Atualização:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.UltimaAtualizacao.ToString() + @"</label>
                <hr/><label style='font-size: medium;font-weight: bold;'>Data Abertura:</label>
                <label style='font-size: small;'> " + cnpjDataViewModel.Abertura.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>Nome Empresarial:</label>
                <label style='font-size: small;'> " + cnpjDataViewModel.Nome.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>Nome Fantasia:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.Fantasia.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>Código e Descrição da Natureza Jurídica: </label>
                <label style='font-size: small;'>" + cnpjDataViewModel.NaturezaJuridica.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>Logradouro:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.Logradouro.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>Número:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.Numero.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>Complemento:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.Complemento.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>CEP:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.Cep.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>Bairro:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.Bairro.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>Endereço Eletrônico:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.Email.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>Município:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.Municipio.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>UF:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.Uf.ValidField() + @"</label>
                <hr/>
                
                <label style='font-size: medium;font-weight: bold;'>Telefone:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.Telefone.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>Capital Social:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.CapitalSocial.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>Situação Cadastral:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.Situacao.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>Data da Situação Cadastral:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.DataSituacao.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>EFR:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.Efr.ValidField() + @"</label>
                
                <hr/>
                <label style='font-size: medium;font-weight: bold;'>Porte:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.Porte.ValidField() + @"</label>
                <hr/>
                
                <label style='font-size: medium;font-weight: bold;'>Motivo da Situação:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.MotivoSituacao.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>Situacão Especial:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.SituacaoEspecial.ValidField() + @"</label>
                <hr/>

                <label style='font-size: medium;font-weight: bold;'>Data da Situacão Especial:</label>
                <label style='font-size: small;'>" + cnpjDataViewModel.DataSituacaoEspecial.ValidField() + @"</label>
                <hr/>";

            if (cnpjDataViewModel.AtividadePrincipal.Any())
            {
                html += @"<br/><br/>
                <label style='font-size: large;font-weight: bold;'>Atividade Econômicas Primárias</label>
                <br/><br/>";
                foreach (var atividadePrincipal in cnpjDataViewModel.AtividadePrincipal)
                {
                    html += @"
                <label style='font-size: medium;font-weight: bold;'>Codigo:</label>
                <label style='font-size: small;'>" + atividadePrincipal.Code.ValidField() + @"</label>
                <br/>
                <label style='font-size: medium;font-weight: bold;'>Descrição:</label>
                <label style='font-size: small;'>" + atividadePrincipal.Text.ValidField() + @"</label>
                <hr/>";
                }

            }
            if (cnpjDataViewModel.AtividadesSecundarias.Any())
            {
                html += @"
                <br/><br/>
                <label style='font-size: large;font-weight: bold;'>Atividade Econômicas Secundárias</label>
                <br/><br/>";
                foreach (var atividadesSecundarias in cnpjDataViewModel.AtividadesSecundarias)
                {
                    html += @"
                <label style='font-size: medium;font-weight: bold;'>Codigo:</label>
                <label style='font-size: small;'>" + atividadesSecundarias.Code.ValidField() + @"</label>
                <br/>
                <label style='font-size: medium;font-weight: bold;'>Descrição:</label>
                <label style='font-size: small;'>" + atividadesSecundarias.Text.ValidField() + @"</label>
                <hr/>";
                }
            }

            if (cnpjDataViewModel.Qsa.Any())
            {
                html += @"
                <br/><br/>
                <label style='font-size: large;font-weight: bold;'>Quadro Societário</label>
                <br/><br/>";

                foreach (var qsa in cnpjDataViewModel.Qsa)
                {
                    html += @"<label style='font-size: medium;font-weight: bold;'>Nome do Sócio:</label>
                <label style='font-size: small;'>" + qsa.Nome.ValidField() + @"</label>
                <br/>
                <label style='font-size: medium;font-weight: bold;'>Nome do Representante legal:</label>
                <label style='font-size: small;'>" + qsa.NomeRepLegal.ValidField() + @"</label>
                <br/>
                <label style='font-size: medium;font-weight: bold;'>País de Origem:</label>
                <label style='font-size: small;'>" + qsa.PaisOrigem.ValidField() + @"</label>
                <br/>
                <label style='font-size: medium;font-weight: bold;'>Qualificação do Sócio:</label>
                <label style='font-size: small;'>" + qsa.Qual.ValidField() + @"</label>
                <br/>
                <label style='font-size: medium;font-weight: bold;'>Qualificação do Representante Legal:</label>
                <label style='font-size: small;'>" + qsa.QualRepLegal.ValidField() + @"</label>
                <hr/>";
                }
            }
            html += @"</div>
                   </body>
                    </html>";

            return await Task.FromResult(html);
        }

        /// <summary>
        /// Gero o Pdf Utilizando o Iron PDF
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public async Task<PdfData> CreatePdfAsync(string html)
        {           
            var renderer = new IronPdf.ChromePdfRenderer();
            renderer.RenderingOptions.CssMediaType = IronPdf.Rendering.PdfCssMediaType.Print;
            using var pdf = await renderer.RenderHtmlAsPdfAsync(html);

            return new PdfData
            {
                ContentLength = pdf.BinaryData.Length.ToString(),
                BinaryData = pdf.BinaryData
            };
        }
    }
}

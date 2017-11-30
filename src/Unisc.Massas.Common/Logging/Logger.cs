using System;
using System.IO;

namespace Unisc.Massas.Core.Logging
{
    public static class Logger
    {
        /// <summary>
        /// Grava o Erro em um arquivo txt.
        /// </summary>
        /// <param name="ex">A Exceção a ser gravada</param>
        /// <param name="titulo">O título da Exceção</param>
        /// <param name="objeto">Objeto adicional para exibição.</param>
        public static void Log(Exception ex, string titulo, object objeto = null)
        {
            var userAppFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            #region Cria Pasta se não Existe

            if (!Directory.Exists(Path.Combine(userAppFolder, @"UNISC\Logs")))
            {
                Directory.CreateDirectory(Path.Combine(userAppFolder, @"UNISC\Logs"));
            }

            #endregion

            #region Cria Arquivo

            string dateAppendage = String.Format("{0}_{1}_{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

            FileStream fs = null;

            try
            {
                //Checa se o arquivo existe, criando se necessário. Gravar o texto usando outro FileStream.
                fs = new FileStream(Path.Combine(userAppFolder, String.Format(@"UNISC\Logs\Log_{0}.txt", dateAppendage)),
                    FileMode.Append, FileAccess.Write);
            }
            catch (Exception)
            {
                dateAppendage = DateTime.Now.ToString("dd_MM_yy hh_mm_ss_ff");
                fs = new FileStream(Path.Combine(userAppFolder, String.Format(@"UNISC\Logs\Log_{0}.txt", dateAppendage)),
                    FileMode.Append, FileAccess.Write);
            }

            var s = new StreamWriter(fs);
            s.Close();
            fs.Close();
            fs.Dispose();

            #endregion

            var fs1 = new FileStream(Path.Combine(userAppFolder, String.Format(@"UNISC\Logs\Log_{0}.txt", dateAppendage)),
                FileMode.Append, FileAccess.Write);

            var s1 = new StreamWriter(fs1);

            s1.WriteLine("► Título - {0}\t{1}", Environment.NewLine, titulo);
            s1.WriteLine("▬ Mensagem - {0}\t{1}", Environment.NewLine, ex.Message);
            s1.WriteLine("♦ Data/Hora - {0}\t{1}", Environment.NewLine, DateTime.Now);
            s1.WriteLine("☻ Tipo - {0}\t{1}", Environment.NewLine, ex.GetType().Name);
            s1.WriteLine("▲ Fonte - {0}\t{1}", Environment.NewLine, ex.Source);
            s1.WriteLine("▼ Origem - {0}\t{1}", Environment.NewLine, ex.TargetSite);
            if (objeto != null)
                s1.WriteLine("◄ Adicional - {0}\t{1}", Environment.NewLine, objeto);
            s1.WriteLine("♠ StackTrace - {0}{1}", Environment.NewLine, ex.StackTrace);

            if (ex.InnerException != null)
            {
                s1.WriteLine();
                s1.WriteLine("▬▬ Mensagem - {0}\t{1}", Environment.NewLine, ex.InnerException.Message);
                s1.WriteLine("☻☻ Tipo - {0}\t{1}", Environment.NewLine, ex.InnerException.GetType().Name);
                s1.WriteLine("▲▲ Fonte - {0}\t{1}", Environment.NewLine, ex.InnerException.Source);
                s1.WriteLine("▼▼ Origem - {0}\t{1}", Environment.NewLine, ex.InnerException.TargetSite);
                s1.WriteLine("♠♠ StackTrace - {0}{1}", Environment.NewLine, ex.InnerException.StackTrace);

                if (ex.InnerException.InnerException != null)
                {
                    s1.WriteLine();
                    s1.WriteLine("▬▬▬ Mensagem - {0}\t{1}", Environment.NewLine, ex.InnerException.InnerException.Message);
                    s1.WriteLine("☻☻☻ Tipo - {0}\t{1}", Environment.NewLine, ex.InnerException.InnerException.GetType().Name);
                    s1.WriteLine("▲▲▲ Fonte - {0}\t{1}", Environment.NewLine, ex.InnerException.InnerException.Source);
                    s1.WriteLine("▼▼▼ Origem - {0}\t{1}", Environment.NewLine, ex.InnerException.InnerException.TargetSite);
                    s1.WriteLine("♠♠♠ StackTrace - {0}\t{1}", Environment.NewLine, ex.InnerException.InnerException.StackTrace);
                }
            }

            s1.WriteLine();
            s1.WriteLine("----------------------------------");
            s1.WriteLine();

            s1.Close();
            fs1.Close();
            fs1.Dispose();
        }

        /// <summary>
        /// Grava a mensagem em um arquivo txt.
        /// </summary>
        /// <param name="titulo">Título da mensagem</param>
        /// <param name="mensagem">Conteúdo da mensagem</param>
        /// <param name="nome">Nome do arquivo.</param>
        public static void Log(string titulo, string mensagem, string nome = "Mensagem")
        {
            try
            {
                var userAppFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                #region Cria Pasta se não Existe

                if (!Directory.Exists(Path.Combine(userAppFolder, @"UNISC\Logs")))
                {
                    Directory.CreateDirectory(Path.Combine(userAppFolder, @"UNISC\Logs"));
                }

                #endregion

                FileStream fs = null;
                string dateAppendage = String.Format("{0}_{1}_{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

                try
                {
                    //Checa se o arquivo existe, criando se necessário. Gravar o texto usando outro FileStream.
                    fs = new FileStream(Path.Combine(userAppFolder, String.Format(@"UNISC\Logs\{0}_{1}.txt", nome, dateAppendage)),
                        FileMode.Append, FileAccess.Write);
                }
                catch (Exception)
                {
                    dateAppendage = DateTime.Now.ToString("dd_MM_yy hh_mm_ss_ff");
                    fs = new FileStream(Path.Combine(userAppFolder, String.Format(@"UNISC\Logs\{0}_{1}.txt", nome, dateAppendage)),
                        FileMode.Append, FileAccess.Write);
                }

                var s = new StreamWriter(fs);
                s.Close();
                fs.Close();
                fs.Dispose();

                // re-open the log file and log the message
                var fs1 = new FileStream(Path.Combine(userAppFolder, String.Format(@"UNISC\Logs\{0}_{1}.txt", nome, dateAppendage)),
                    FileMode.Append, FileAccess.Write);

                var s1 = new StreamWriter(fs1);

                s1.WriteLine("{0} ♦ {1} • {2}", DateTime.Now.ToString("G"), titulo, mensagem);

                s1.Close();
                fs1.Close();
                fs1.Dispose();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Erro ao gravar mensagem.");
            }
        }

        /// <summary>
        /// Grava a mensagem em um arquivo txt.
        /// </summary>
        /// <param name="titulo">Título da mensagem</param>
        /// <param name="format">String de formatação</param>
        /// <param name="param">Parãmetros da formatação</param>
        public static void Log(string titulo, string format, params object[] param)
        {
            Log(titulo, String.Format(format, param));
        }
    }
}

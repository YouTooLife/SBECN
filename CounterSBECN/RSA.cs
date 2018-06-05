using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CounterSBECN
{
    public class RSA
    {

        private BigInteger NOD(BigInteger x, BigInteger y)
        {
            //Console.Out.WriteLine(x + " " + y);
            if (!x.IsZero)
                return NOD(y % x, x);
            else
                return y;
        }

        private BigInteger Eps(BigInteger fi)
        {
            BigInteger ee = new BigInteger(3);
            while (!NOD(ee, fi).IsOne)
            {
                ee++;
            }
            return ee;
        }

        private BigInteger modInverse(BigInteger a, BigInteger n)
        {
            BigInteger i = n, v = 0, d = 1;
            while (a > 0)
            {
                BigInteger t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;
            return v;
        }

        private BigInteger Encrypt(BigInteger message)
        {
            return BigInteger.ModPow(message, eps, n);
        }

        public string Encrypt(string message)
        {
            string eMsg = "";
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] msg = encoding.GetBytes(message);
            List<byte> tmp = new List<byte>();
            for (int i = 0; i < msg.Length; i++)
            {
                tmp.Add(msg[i]);
                if ((i + 1) % 128 == 0 || i == msg.Length - 1)
                {
                    eMsg += Encrypt(new BigInteger(tmp.ToArray())).ToString() + "#";
                    tmp.Clear();
                }
            }
            return eMsg;
        }


        private BigInteger Decrypt(BigInteger encrypted)
        {
            return BigInteger.ModPow(encrypted, d, n);
        }

        public string Decrypt(string eMsg)
        {
            string message = "";
            char[] sep = { '#' };
            string[] strs = eMsg.Split(sep);
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
            Console.Out.WriteLine(strs.Length);
            for (int i = 0; i < strs.Length; i++)
            {
                BigInteger bt;
                if (!BigInteger.TryParse(strs[i], out bt))
                    break;
                //Console.Out.WriteLine(strs[i]);
                // BigInteger  = BigInteger.Parse(strs[i]);
                byte[] decBytes = Decrypt(bt).ToByteArray();
                message += enc.GetString(decBytes);
                Console.Out.WriteLine(i + "|||" + enc.GetString(decBytes));
            }
            return message;
        }


        public BigInteger p, q, n,
        eps, d,
        fi;

        public RSA(BigInteger eps, BigInteger n)
        {
            /*int N = 1024;
            //SecureRandom random = new SecureRandom();
            //p = BigInteger.probablePrime(N >> 1, random);
            string s = "103895472127986219394306031679782856326108682570342699522247606366744701518078316161502336251923657316007257189188521754824964671537280648829233389765014116017362873770182917607193209373255481403638962575018764334667417781933474055464197921259238996373520849310549933098849929941727990531875292589747991524033";
            p = BigInteger.Parse(s);
            s = "89959391228180925000708500196118418150141290952524259866227907950746205952097486934943311495208974223881987858585842534774258969872372605632525092756987005262261627300954918041876761353298745861166666929903325367880671540514950505494368583114471381729274036293891072142304343964488124656747524068651688089569";
            q = BigInteger.Parse(s);

            Console.Out.WriteLine(p);
            Console.Out.WriteLine(q);

            n = BigInteger.Multiply(p, q);
            Console.Out.WriteLine("n:" + n);

            fi = BigInteger.Multiply(BigInteger.Add(p, BigInteger.MinusOne),
                BigInteger.Add(q, BigInteger.MinusOne));
            Console.Out.WriteLine("fi:" + fi);

            eps = Eps(fi);
            Console.Out.WriteLine("eps:" + eps);

            d = modInverse(eps, fi);
            Console.Out.WriteLine("d:" + d);*/
            this.eps = eps;
            this.n = n;
        }
        public RSA()
        {
            int N = 1024;

            var bat = new StreamWriter("run.bat");
            bat.WriteLine("java -jar \"" + AppDomain.CurrentDomain.BaseDirectory + "\\BigPrime.jar\" " + N.ToString());
            bat.Close();
            var proc = Process.Start("run.bat");
            proc.WaitForExit();

            var reader = new StreamReader("primes.txt");

            //string s = "103895472127986219394306031679782856326108682570342699522247606366744701518078316161502336251923657316007257189188521754824964671537280648829233389765014116017362873770182917607193209373255481403638962575018764334667417781933474055464197921259238996373520849310549933098849929941727990531875292589747991524033";
            string s = reader.ReadLine();
            p = BigInteger.Parse(s);
            s = reader.ReadLine();
            //s = "89959391228180925000708500196118418150141290952524259866227907950746205952097486934943311495208974223881987858585842534774258969872372605632525092756987005262261627300954918041876761353298745861166666929903325367880671540514950505494368583114471381729274036293891072142304343964488124656747524068651688089569";
            q = BigInteger.Parse(s);

            reader.Close();

            //Console.Out.WriteLine(p);
            //Console.Out.WriteLine(q);

            n = BigInteger.Multiply(p, q);
            //Console.Out.WriteLine("n:" + n);

            fi = BigInteger.Multiply(BigInteger.Add(p, BigInteger.MinusOne),
                BigInteger.Add(q, BigInteger.MinusOne));
            //Console.Out.WriteLine("fi:" + fi);

            eps = Eps(fi);
            Console.Out.WriteLine("eps:" + eps);

            d = modInverse(eps, fi);
            Console.Out.WriteLine("d:" + d);
            Console.Out.WriteLine("endRSA");
        }
    }
}

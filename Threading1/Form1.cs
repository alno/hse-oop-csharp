using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Threading1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private StringBuilder b;

        private object lockObject = new Object();

        private void t1Start()
        {
            for (int i = 0; i < 100; ++i)
            {
                lock (lockObject)
                {
                    // tbOut.Text += (i + "b"); // НЕВЕРНО - другой поток
                    b.Append(i + "a ");
                    Thread.Sleep(1);
                }
            }
        }

        private void t1Mult(int mult)
        {
            for (int i = 0; i < 100; ++i)
            {
                lock (lockObject)
                {
                    // tbOut.Text += (i + "b"); // НЕВЕРНО - другой поток
                    b.Append(i * mult + "a ");
                    Thread.Sleep(1);
                }
            }
        }

        private void ttWithData(object data)
        {
            for (int i = 0; i < 100; ++i)
            {
                lock (lockObject)
                {
                    // tbOut.Text += (i + "b"); // НЕВЕРНО - другой поток
                    b.Append(i + "a" + data + " ");
                    Thread.Sleep(0);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; ++i)
            {
                // progressBar.Value = i; // НЕВЕРНО - другой поток
                bw1.ReportProgress(i); // ВЕРНО
                Thread.Sleep(200);
            }
        }

        private void bt10_Click(object sender, EventArgs e)
        {
            bw1.RunWorkerAsync();
        }

        private void bw1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(new ThreadStart(t1Start));
            Thread t2 = new Thread(t1Start);
            Thread t3 = new Thread(() => t1Start());
            Thread t4 = new Thread(() =>
            {
                int i = 0;
                i = i + 2;
                t1Start();
            });
            Thread t5 = new Thread(delegate()
            {
                t1Start();
            });

            b = new StringBuilder();

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();

            tbOut.Text = b.ToString();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(() => t1Mult(5));

            Thread t2 = new Thread(delegate()
            {
                t1Mult(7);
            });

            b = new StringBuilder();

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            tbOut.Text = b.ToString();
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            b = new StringBuilder();
            ThreadPool.QueueUserWorkItem(ttWithData, 1);
            ThreadPool.QueueUserWorkItem(ttWithData, 3);
            Thread.Sleep(1000);
            tbOut.Text = b.ToString();
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            b = new StringBuilder();

            ThreadStart ts = new ThreadStart(t1Start);
            IAsyncResult r1 = ts.BeginInvoke(null, null);
            IAsyncResult r2 = ts.BeginInvoke(null, null);

            ts.EndInvoke(r1);
            ts.EndInvoke(r2);

            tbOut.Text = b.ToString();
        }

        delegate void ForkTaken(int phil, int fork);
        delegate void PhilosopherEated(int phil, int count);

        const int COUNT = 5;

        private object[] forks = new object[COUNT];
        private int[] eats = new int[COUNT];

        private event PhilosopherEated Eated;
        private event ForkTaken Taken;

        private void btPhilosophers_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < COUNT; ++i)
            {
                forks[i] = new object();
                eats[i] = 5;
            }

            Eated += (int phil, int count) =>
            {
                tbOut.Text += "Philosopher " + phil + " eated. " + count + " left\n";
            };

            Taken += (int phil, int fork) =>
            {
                tbOut.Text += "Philosopher " + phil + " took fork " + fork + "\n";
            };

            for (int i = 0; i < COUNT; ++i)
            {
                int phil = i;
                new Thread(() => philosopher(phil)).Start();
            }
        }

        private Random rand = new Random();

        private void philosopher(int i)
        {
            while (eats[i] > 0)
            {
                int f1 = i;
                int f2 = (i + 1) % COUNT;

                lock (forks[f1])
                {
                    Invoke(Taken, i, f1);
                    lock (forks[f2])
                    {
                        Invoke(Taken,i, f2);
                        eats[i]--;
                        Thread.Sleep(rand.Next(100));
                        Invoke(Eated,i, eats[i]);
                    }
                }
            }
        }
    }
}

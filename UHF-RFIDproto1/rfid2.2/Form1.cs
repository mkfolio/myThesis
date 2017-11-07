using System;
using System.Text;
using System.Windows.Forms;
using ReaderB;

namespace rfid2._2
{
    public partial class Form1 : Form
    {
        private bool fAppClosed;
        private int port;
        private int OpenedPort;
        private byte ComAddr = 0xFF;
        private byte Baud;
        private int frmcomportindex;
        private int fOpenComIndex;
        private bool ComOpen = false;
        private int fCmdRet = 30;
        private bool fIsInventoryScan;
        private string fInventory_EPC_List;

        public Form1()
        {
            InitializeComponent();
        }

        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fIsInventoryScan = false;
            QueryTab.Enabled = false;
        }

        private void AutoOpenCOM_Click(object sender, EventArgs e)
        {
            port = 0;
            int openresult;

            openresult = 30;

            Cursor = Cursors.WaitCursor;

            try
            {
                ComAddr = Convert.ToByte("FF", 16);
                Baud = Convert.ToByte(5);
                openresult = StaticClassReaderB.AutoOpenComPort(ref port, ref ComAddr, Baud, ref frmcomportindex);
                fOpenComIndex = frmcomportindex;
                if(openresult == 0)
                {
                    ComOpen = true;
                    OpenedPort = port;

                    if ((fCmdRet == 0x35) | (fCmdRet == 0x30))
                    {
                        MessageBox.Show("Serial Communication Error or Occupied", "Error" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                        StaticClassReaderB.CloseSpecComPort(frmcomportindex);
                        ComOpen = false;
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if ((fOpenComIndex != -1 ) & (openresult != 0X35 ) & (openresult != 0X30 ))
            {
                MessageBox.Show("Com Port Activated");
                QueryTab.Enabled = true;
            }

            if ((fOpenComIndex == -1) && (openresult == 0x30))
            {
                MessageBox.Show("Serial Communication Error", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
               

        }

        private void QueryTag_Click(object sender, EventArgs e)
        {
            Timer_Test_.Enabled = !Timer_Test_.Enabled;
            if (!Timer_Test_.Enabled)
            {
                QueryTag.Text = "Query Tag";
            }
            else
            {
                ListView1_EPC.Items.Clear();
                QueryTag.Text = "Stop";
            }
        }

        public void ChangeSubItem(ListViewItem ListItem, int subItemIndex, string ItemText)
        {
            if (subItemIndex == 1)
            {
                if (ItemText == "")
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                    if (ListItem.SubItems[subItemIndex + 2].Text == "")
                    {
                        ListItem.SubItems[subItemIndex + 2].Text = "1";
                    }
                    else
                    {
                        ListItem.SubItems[subItemIndex + 2].Text = Convert.ToString(Convert.ToInt32(ListItem.SubItems[subItemIndex + 2].Text) + 1);
                    }
                }

                else
                if (ListItem.SubItems[subItemIndex].Text != ItemText)
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                    ListItem.SubItems[subItemIndex + 2].Text = "1";
                }

                else
                {
                    ListItem.SubItems[subItemIndex + 2].Text = Convert.ToString(Convert.ToInt32(ListItem.SubItems[subItemIndex + 2].Text) + 1);
                    if ((Convert.ToUInt32(ListItem.SubItems[subItemIndex + 2].Text) > 9999))
                        ListItem.SubItems[subItemIndex + 2].Text = "1";
                }

            }

            if (subItemIndex == 2)
            {
                if (ListItem.SubItems[subItemIndex].Text != ItemText)
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                }
            }

        }

        private void Timer_Test__Tick(object sender, EventArgs e)
        {
            if (fIsInventoryScan)
                return;
            Inventory();
        }

        private void Inventory()
        {
            int i;
            int CardNum = 0;
            int Totallen = 0;
            int EPClen, m;
            byte[] EPC = new byte[5000];
            int CardIndex;
            string temps;
            string s, sEPC;
            bool isonlistview;
            fIsInventoryScan = true;
            byte AdrTID = 0;
            byte LenTID = 0;
            byte TIDFlag = 0;

            ListViewItem aListItem = new ListViewItem();
            fCmdRet = StaticClassReaderB.Inventory_G2(ref ComAddr, AdrTID, LenTID, TIDFlag, EPC, ref Totallen, ref CardNum, frmcomportindex);
            //Start Read
            if((fCmdRet == 1) | (fCmdRet == 2) | (fCmdRet == 3) | (fCmdRet == 4) | (fCmdRet == 0xFB))
            {
                byte[] daw = new byte[Totallen];
                Array.Copy(EPC, daw, Totallen);
                temps = ByteArrayToHexString(daw);
                fInventory_EPC_List = temps;
                m = 0;

                if (CardNum == 0)
                {
                    fIsInventoryScan = false;
                    return;
                }
                for (CardIndex = 0;CardIndex<CardNum;CardIndex++)
                {
                    EPClen = daw[m];
                    sEPC = temps.Substring(m * 2 + 2, EPClen * 2);
                    m = m + EPClen + 1;

                    if (sEPC.Length != EPClen * 2)
                    return;
                    
                    isonlistview = false;
                    for (i = 0; i < ListView1_EPC.Items.Count; i++)
                    {
                        if (sEPC == ListView1_EPC.Items[i].SubItems[1].Text)
                        {
                            aListItem = ListView1_EPC.Items[i];
                            ChangeSubItem(aListItem, 1, sEPC);
                            isonlistview = true;
                        }
                    }

                    if (!isonlistview)
                    {
                        aListItem = ListView1_EPC.Items.Add((ListView1_EPC.Items.Count + 1).ToString());
                        aListItem.SubItems.Add("");
                        aListItem.SubItems.Add("");
                        aListItem.SubItems.Add("");
                        s = sEPC;
                        ChangeSubItem(aListItem, 1, s);
                        s = (sEPC.Length / 2).ToString().PadLeft(2, '0');
                        ChangeSubItem(aListItem, 2, s);
                    }
                }
            }
            fIsInventoryScan = false;
            if (fAppClosed)
                Close();

        }

        private void ClosePort_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor = Cursors.WaitCursor;
               
                fCmdRet = StaticClassReaderB.CloseSpecComPort(OpenedPort);
                if (fCmdRet == 0)
                {
                    ComOpen = false;
                    QueryTab.Enabled = false;
                    MessageBox.Show("Com Port Closed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Serial Communication Error", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}

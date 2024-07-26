using BrightIdeasSoftware;
using MyDMS.Secretariat;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using PNB.Helpers;

namespace PNB.MyDMS
{
	public partial class ucCMS : UserControl
	{
		Secretarait sec;
		public ucCMS(Secretarait secretarait)
		{
			sec = secretarait;
			InitializeComponent();

			SetupTree();

			olv.KeyUp += Olv_KeyUp;
			olv.SelectedIndexChanged += Olv_SelectedIndexChanged;
			olv.DoubleClick += Olv_DoubleClick;
			RefreashTreeView();
			olv.ExpandAll();

			tsbtnAdd.Click += tsbtnAdd_Click;
			tsbtnEdit.Click += tsbtnEdit_Click;
		}

		private void Olv_DoubleClick(object sender, EventArgs e)
		{
			Point p = olv.PointToClient(Form.MousePosition);
			ListViewItem item = olv.GetItemAt(p.X, p.Y);
			if (item == null) return;

			OLVListItem i2 = item as OLVListItem;
			if (i2.RowObject is OEntity)
			{
				DoAddNewCall();//Olv_DoubleClick
			}
		}

		public void RefreashTreeView()
		{
			olv.Roots = sec.Organizations;
		}

		private void Olv_SelectedIndexChanged(object sender, EventArgs e)
		{
			tsbtnAdd.Enabled = tsbtnEdit.Enabled = olv.SelectedItem != null;

			if (olv.SelectedItem == null) return;


			if (olv.SelectedItem.RowObject is OEntity)
			{
				OEntity oe = olv.SelectedItem.RowObject as OEntity;
				Organization org = sec.Organizations.Find(x => x.ID == oe.Owner);
				List<Call> calls = org.Calls.FindAll(x => x.OE == oe.ID);
				DoPopulateCallsListview(calls);
			}
			if (olv.SelectedItem.RowObject is Organization)
			{
				Organization org = olv.SelectedItem.RowObject as Organization;
				DoPopulateCallsListview(org);
			}
		}

		private void Olv_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F3)
				txtName.Focus();
			else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Insert)
				DoAddNewCall();//Olv_KeyUp
		}
		private void txtName_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				olv.Focus();
			}
			string txt = txtName.Text.Trim();
			//if (txt.Length >= 3)
			DoSearchOrgs(txt, 0);
		}
		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			DoAddNewCall();//tsbtnAdd_Click
		}
		private void lstvwCalls_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstvwCalls.SelectedItems.Count == 0)
			{
				textBox1.Text = string.Empty;
				return;
			}

			Call c = lstvwCalls.SelectedItems[0].Tag as Call;
			textBox1.Text = c.Description;
		}
		private void lstvwCalls_DoubleClick(object sender, EventArgs e)
		{
			Point p = lstvwCalls.PointToClient(Form.MousePosition);
			ListViewItem item = lstvwCalls.GetItemAt(p.X, p.Y);

			DoEditCallItem(item);
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			ListViewItem item = lstvwCalls.SelectedItems.Count > 0 ? lstvwCalls.SelectedItems[0] : null;
			DoEditCallItem(item);
		}
		private void DoEditCallItem(ListViewItem item)
		{
			if (item == null) return;

			Call call1 = item.Tag as Call;

			Organization org = sec.Organizations.Find(x => x.Entities.Find(en1 => en1.ID == call1.OE) != null);
			if (org == null) return;
			OEntity oe = org.Entities.Find(y => y.ID == call1.OE);
			ucSingleCMS uc1 = new ucSingleCMS(org, oe, call1);
			if (uc1.ShowDialog(this) == DialogResult.Cancel)
				return;
		}
		private void DoSearchOrgs(string txt, int matchKind)
		{
			TextMatchFilter filter = null;
			//if (!String.IsNullOrEmpty(txt))
			//{
			switch (matchKind)
			{
				case 0:
				default:
					filter = TextMatchFilter.Contains(olv, txt);
					break;
				case 1:
					filter = TextMatchFilter.Prefix(olv, txt);
					break;
				case 2:
					filter = TextMatchFilter.Regex(olv, txt);
					break;
			}
			//}

			// Text highlighting requires at least a default renderer
			if (olv.DefaultRenderer == null)
				olv.DefaultRenderer = new HighlightTextRenderer(filter);

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();
			olv.AdditionalFilter = filter;
			//olv.Invalidate();
			stopWatch.Stop();

			//ist objects = olv.Objects as IList;
			//if (objects == null)
			//	ToolStripStatus1 = prefixForNextSelectionMessage = $"Filtered in {stopWatch.ElapsedMilliseconds}ms";
			//else
			//	ToolStripStatus1 = prefixForNextSelectionMessage = $"Filtered {objects.Count} items down to {olv.Items.Count} items in {stopWatch.ElapsedMilliseconds}ms";
		}

		private void SetupTree()
		{
			// TreeListView require two delegates:
			// 1. CanExpandGetter - Can a particular model be expanded?
			// 2. ChildrenGetter - Once the CanExpandGetter returns true, ChildrenGetter should return the list of children

			// CanExpandGetter is called very often! It must be very fast.
			this.olv.CanExpandGetter = delegate (object x)
			{
				bool canExpand = false;

				if (x is OEntity) canExpand = false;
				else if (x is Organization) canExpand = true;

				return canExpand;// ((MyFileSystemInfo)x).IsDirectory;
			};

			this.olv.SelectedIndexChanged += delegate (object sender, EventArgs e)
			{
				if (olv.SelectedItem == null) return;
				tsbtnAdd.Enabled = olv.SelectedItem.RowObject is OEntity;
			};

			// We just want to get the children of the given directory.
			// This becomes a little complicated when we can't (for whatever reason). We need to report the error 
			// to the user, but we can't just call MessageBox.Show() directly, since that would stall the UI thread
			// leaving the tree in a potentially undefined state (not good). We also don't want to keep trying to
			// get the contents of the given directory if the tree is refreshed. To get around the first problem,
			// we immediately return an empty list of children and use BeginInvoke to show the MessageBox at the 
			// earliest opportunity. We get around the second problem by collapsing the branch again, so it's children
			// will not be fetched when the tree is refreshed. The user could still explicitly unroll it again --
			// that's their problem :)
			this.olv.ChildrenGetter = delegate (object x)
			{
				IEnumerable x1 = null;
				try
				{
					if (x is Organization)
					{
						Organization org = x as Organization;
						x1 = org.Entities;// ((MyFileSystemInfo)x).GetFileSystemInfos();}
					}
					else if (x is OEntity)
					{
						OEntity office = x1 as OEntity;
						x1 = office.PhoneNumbers;
					}

					return x1;
				}
				catch (UnauthorizedAccessException ex)
				{
					this.BeginInvoke((MethodInvoker)delegate ()
					{
						this.olv.Collapse(x);
						MessageBox.Show(this, ex.Message, "ObjectListViewDemo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					});
					return new ArrayList();
				}
			};

			// Once those two delegates are in place, the TreeListView starts working
			// after setting the Roots property.

			// List all drives as the roots of the tree
			//ArrayList roots = new ArrayList();
			//foreach (DriveInfo di in DriveInfo.GetDrives())
			//{
			//	if (di.IsReady)
			//		roots.Add(new MyFileSystemInfo(new DirectoryInfo(di.Name)));
			//}
			//this.treeListView.Roots = roots;
		}

		private void DoAddNewCall()
		{
			if (olv.SelectedItem.RowObject is Organization)
			{
				Organization org = olv.SelectedItem.RowObject as Organization;
			}
			else if (olv.SelectedItem.RowObject is OEntity)
			{
				OEntity oe = olv.SelectedItem.RowObject as OEntity;
				Organization org = sec.Organizations.Find(x => x.ID == oe.Owner);
				if (org == null) return;

				ucSingleCMS uc1 = new ucSingleCMS(org, oe);
				if (uc1.ShowDialog(this) == DialogResult.Cancel)
					return;

				org.Calls.Add(uc1.CallData);
				DoAddSingleCall(uc1.CallData);
			}
		}
		private void DoPopulateCallsListview(Organization org)
		{
			lstvwCalls.Items.Clear();
			org.Calls.ForEach(c => { DoAddSingleCall(c); });
		}
		private void DoPopulateCallsListview(List<Call> calls)
		{
			lstvwCalls.Items.Clear();
			calls.ForEach(c => { DoAddSingleCall(c); });
		}
		private void DoAddSingleCall(Call call)
		{
			string dt = PersianCalendar.GregorianToJalali(call.CreatetionDate, false);
			ListViewItem item = new ListViewItem(dt);
			item.SubItems.Add(call.Subject);
			Organization org = sec.Organizations.Find(x => x.Entities.Find(en1 => en1.ID == call.OE) != null);
			if (org == null) return;
			OEntity oe = org.Entities.Find(y => y.ID == call.OE);
			item.SubItems.Add(oe.Name);
			item.Tag = call;
			lstvwCalls.Items.Add(item);
		}

		private void tsbtnCollapse_Click(object sender, EventArgs e)
		{
			DoCollapseExpand(1);
		}
		private void tsbtnExpand_Click(object sender, EventArgs e)
		{
			DoCollapseExpand(2);
		}

		private void DoCollapseExpand(int v1)
		{
			if (v1 == 1)
				olv.CollapseAll();
			else if (v1 == 2)
				olv.ExpandAll();
		}
	}
}
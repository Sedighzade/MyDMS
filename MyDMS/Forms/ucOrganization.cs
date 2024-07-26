using MyDMS.Secretariat;
using PNB.GUI.GUIHelper;
using PNB.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PNB.MyDMS
{
	public partial class ucOrganization : UserControl
	{
		public event EventHandler DataChanged;
		List<Organization> cache = new List<Organization>();
		Secretarait sec1;


		public ucOrganization(Secretarait sec)
		{
			sec1 = sec;

			InitializeComponent();

			List<Organization> l1 = Util.DeepClone<List<Organization>>(sec.Organizations);
			if (l1 != null)
				cache.AddRange(l1);

			DoSortOrg();
			DoPopulateOrgListview(cache);
			DoSetOrgCount();///constructor


			txtOrgName.KeyUp += delegate (object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Down)
				{
					lstbxOrg.Focus();
					return;
				}
				if (e.KeyCode == Keys.Enter)
				{
					DoAddNewOrg();//KeyUp					
					///clear, coz in DoAddNewOrg we add newly added item to the listbox
					return;
				}
				DoClearAll();
				if (string.IsNullOrEmpty(txtOrgName.Text))
				{
					DoPopulateOrgListview(cache);
					return;
				}
				List<Organization> lst = cache.FindAll(x => x.Name.Contains(txtOrgName.Text));
				DoPopulateOrgListview(lst);

				if (lstbxOrg.Items.Count > 0)
					lstbxOrg.Items[0].Selected = true;
			};
			tsbtnSave.Click += delegate (object sender, System.EventArgs e)
			{
				DoSave(true);
			};
			tsbtnAddOrganization.Click += delegate (object sender, System.EventArgs e)
			{
				DoAddNewOrg();//btnAdd_Click
			};
			tsbtnDeleteOrganization.Click += delegate (object sender, System.EventArgs e)
			{
				if (lstbxOrg.SelectedItems.Count == 0) return;
				ListViewItem item = lstbxOrg.SelectedItems[0];
				if (MessageBox.Show(this, "Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return;

				lstbxOrg.Items.Remove(item);
				cache.Remove(item.Tag as Organization);
				lstbxEntity.Items.Clear();
				prptOffice.SelectedObject = null;

				DoSetOrgCount();//tsbtnDeleteOrganization
				DoRefreshOthers();
			};
			lstbxOrg.SelectedIndexChanged += delegate
			{
				tsbtnDeleteOrganization.Enabled = tsbtnAddEntity.Enabled = lstbxOrg.SelectedItems.Count > 0;

				if (lstbxOrg.SelectedItems.Count == 0) return;
				ListViewItem item = lstbxOrg.SelectedItems[0];
				Organization org = item.Tag as Organization;

				DoPopulateEntities(org);//SelectedIndexChanged
				org.ClickedTimes++;
			};
			lstbxEntity.SelectedIndexChanged += delegate
			{
				tsbtnDeleteEntity.Enabled = lstbxEntity.SelectedItem != null;
				prptOffice.SelectedObject = lstbxEntity.SelectedItem;
			};
			tsbtnAddEntity.Click += delegate (object sender, EventArgs e)
			{
				Organization org = lstbxOrg.SelectedItems[0].Tag as Organization;
				DoAddNewEntity(org);
			};
			tsbtnDeleteEntity.Click += delegate (object sender, EventArgs e)
			{
				if (lstbxOrg.SelectedItems.Count == 0) return;
				if (lstbxEntity.SelectedItem == null) return;

				Organization org = lstbxOrg.SelectedItems[0].Tag as Organization;
				OEntity oe = lstbxEntity.SelectedItem as OEntity;

				if (MessageBox.Show(this, "Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return;
				org.Entities.Remove(oe);
				int idx = lstbxEntity.Items.IndexOf(oe);
				lstbxEntity.Items.Remove(oe);
				prptOffice.SelectedObject = null;
				if (lstbxEntity.Items.Count == 0) return;

				if (idx == 0)
					lstbxEntity.SelectedItem = lstbxEntity.Items[0];
				else
					lstbxEntity.SelectedItem = lstbxEntity.Items[idx - 1];
			};


			if (lstbxOrg.Items.Count > 0)
				lstbxOrg.Items[0].Selected = true;
		}

		private void DoClearAll()
		{
			lstbxOrg.Items.Clear();
			lstbxEntity.Items.Clear();
			prptOffice.SelectedObject = null;
		}

		private void DoSave(bool showMsg)
		{
			sec1.Organizations.Clear();
			sec1.Organizations.AddRange(cache.ToArray());
			if (showMsg)
				MessageBox.Show(this, "Saved", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void DoSortOrg()
		{
			cache.Sort(delegate (Organization x, Organization y)
			{
				return y.ClickedTimes.CompareTo(x.ClickedTimes);
			});
		}
		private void DoSetOrgCount()
		{
			tslblOrgCount.Text = "Count: " + lstbxOrg.Items.Count;
		}


		private Organization DoAddNewOrg()
		{
			if (string.IsNullOrWhiteSpace(txtOrgName.Text))
			{
				MessageBox.Show(this, "Empty Name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
			Organization org = new Organization();
			org.Name = txtOrgName.Text.Trim();
			cache.Add(org);

			DoSortOrg();

			DoPopulateOrgListview(cache);

			DoSetOrgCount();//DoAddNewOrg

			ListViewItem[] items = lstbxOrg.Items.Find(org.Name, false);
			lstbxOrg.EnsureVisible(items[0].Index);
			items[0].Selected = true;

			txtOrgName.Text = "";
			txtOrgName.Focus();

			DoRefreshOthers();

			return org;
		}
		private void DoPopulateOrgListview(List<Organization> lst)
		{
			DoClearAll();
			List<ListViewItem> items = new List<ListViewItem>();
			lst.ForEach(q =>
			{
				ListViewItem item = DoCreateSingleOrg(q);
				items.Add(item);
			});
			lstbxOrg.Items.AddRange(items.ToArray());
		}
		private ListViewItem DoCreateSingleOrg(Organization org)
		{
			ListViewItem item = new ListViewItem();
			item.Tag = org;
			item.Text = item.Name = org.Name;

			return item;
		}

		private void DoPopulateEntities(Organization org)
		{
			lstbxEntity.Items.Clear();
			prptOffice.SelectedObject = null;

			OEntity[] ofcs = org.Entities.ToArray();
			lstbxEntity.Items.AddRange(ofcs);
			if (ofcs.Length > 0)
				lstbxEntity.SelectedIndex = 0;
		}
		private void DoAddNewEntity(Organization org)
		{
			string newName = frmSingleValue.GetSingleValueFromUser(this, "Enter New Name", "New Name", string.Empty, false);
			if (string.IsNullOrEmpty(newName)) return;

			OEntity oe = new OEntity();
			oe.Name = newName;
			oe.Owner = org.ID;
			org.Entities.Insert(0, oe);
			lstbxEntity.Items.Insert(0, oe);
			lstbxEntity.SelectedIndex = 0;

			//Refresh Others
			DoRefreshOthers();
		}

		private void DoRefreshOthers()
		{
			DoSave(false);
			DataChanged?.Invoke(this, null);
		}

	}
}

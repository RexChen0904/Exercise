using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected int editId
    {
        get
        {
            return ViewState["editId"] as int? ?? 0;
        }
        set
        {
            ViewState["editId"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            RefreshData();
        }
    }

    private void RefreshData()
    {
        var db = new dbEntities();
        List<Member> members = db.Member.ToList();
        GridView1.DataSource = members;
        GridView1.DataBind();
    }

    private void ClearInput()
    {
        txtName.Text = string.Empty;
        txtAge.Text = string.Empty;
        txtBirthday.Text = string.Empty;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var member = new Member();
        member.Name = txtName.Text;
        if(!int.TryParse(txtAge.Text, out int iAge) || iAge < 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('年齡請輸入正整數');", true);
            return;
        }
        member.Age = iAge;
        member.Birthday = txtBirthday.Text;
        var db = new dbEntities();
        db.Member.Add(member);
        db.SaveChanges();
        ClearInput();
        RefreshData();
    }

    protected void btnEditSubmit_Click(object sender, EventArgs e)
    {
        var db = new dbEntities();
        var member = db.Member.Find(editId);
        if(member != null)
        {
            member.Name = txtName.Text;
            if (!int.TryParse(txtAge.Text, out int iAge) || iAge < 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('年齡請輸入正整數');", true);
                return;
            }
            member.Age = iAge;
            member.Birthday = txtBirthday.Text;
            db.SaveChanges();
            editId = 0;
            ClearInput();
            RefreshData();
        }
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        e.Cancel = true;
        int index = e.NewEditIndex;
        int id = (int)GridView1.DataKeys[index].Value;
        var db = new dbEntities();
        var member = db.Member.Find(id);
        if(member != null)
        {
            editId = id;
            txtName.Text = member.Name;
            txtAge.Text = member.Age.ToString();
            txtBirthday.Text = member.Birthday;
            updatePanel.Update();
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        int id = (int)GridView1.DataKeys[index].Value;
        var db = new dbEntities();
        var member = db.Member.Find(id);
        if (member != null)
        {
            db.Member.Remove(member);
            db.SaveChanges();
            RefreshData();
        }
    }
}
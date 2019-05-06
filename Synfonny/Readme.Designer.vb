<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Readme
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnName = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnAbort = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(220, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Synfonny beta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(333, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Framework VB para crear aplicaciones de escritorio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(69, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(639, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "1. Configurar la conxión de la base de datos. para poder configurar, usted debe i" & _
    "ngresar al  archivo que esta en: ./config/DBConfig.vb"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(39, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Instalación"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(657, 460)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(64, 13)
        Me.LinkLabel1.TabIndex = 6
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "https://github.com/jocker2206/Synfonny"
        Me.LinkLabel1.Text = "Docs Oficial"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(69, 207)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(198, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "2. Crear base de datos {base_de_datos}"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(69, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "3. Crear tabla Users"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(69, 259)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(509, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "4. crear atributos: id: int(11), name: varchar(40), edad: int(2), created_at: tim" & _
    "estamp, updated_at: timestamp"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(69, 319)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(170, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "6. Hacer click en el boton ""Name"""
        '
        'btnName
        '
        Me.btnName.Location = New System.Drawing.Point(42, 361)
        Me.btnName.Name = "btnName"
        Me.btnName.Size = New System.Drawing.Size(75, 23)
        Me.btnName.TabIndex = 11
        Me.btnName.Text = "Name"
        Me.btnName.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(69, 288)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(153, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "5. Realizar un par de consultas"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(164, 440)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 13
        Me.btnEdit.Text = "Editar"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Enabled = False
        Me.btnUpdate.Location = New System.Drawing.Point(256, 397)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 14
        Me.btnUpdate.Text = "Actualizar"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(42, 399)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(197, 20)
        Me.txtName.TabIndex = 15
        '
        'btnAbort
        '
        Me.btnAbort.Enabled = False
        Me.btnAbort.Location = New System.Drawing.Point(42, 440)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(75, 23)
        Me.btnAbort.TabIndex = 16
        Me.btnAbort.Text = "Cancelar"
        Me.btnAbort.UseVisualStyleBackColor = True
        '
        'Readme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 492)
        Me.Controls.Add(Me.btnAbort)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Readme"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnName As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents btnAbort As System.Windows.Forms.Button

End Class

﻿#pragma checksum "..\..\CadastroAluno.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FF9970937D25A32EC9516BCF19902EBB73F67931D8638DD49ACFA147177FF484"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using CadastroResponsavelAluno;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CadastroResponsavelAluno {
    
    
    /// <summary>
    /// CadastroAluno
    /// </summary>
    public partial class CadastroAluno : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\CadastroAluno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelCadastroResponsavel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\CadastroAluno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox campoNome;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\CadastroAluno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelNome;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\CadastroAluno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox campoAno;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\CadastroAluno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelAno;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\CadastroAluno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox campoTurma;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\CadastroAluno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelTurma;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\CadastroAluno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botaoCadastrar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CadastroResponsavelAluno;component/cadastroaluno.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CadastroAluno.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.labelCadastroResponsavel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.campoNome = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\CadastroAluno.xaml"
            this.campoNome.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.campoNome_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.labelNome = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.campoAno = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\CadastroAluno.xaml"
            this.campoAno.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.campoCPF_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.labelAno = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.campoTurma = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\CadastroAluno.xaml"
            this.campoTurma.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.campoTelefone_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.labelTurma = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.botaoCadastrar = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\CadastroAluno.xaml"
            this.botaoCadastrar.Click += new System.Windows.RoutedEventHandler(this.botaoCadastrar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


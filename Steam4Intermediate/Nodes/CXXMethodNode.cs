using System;
using System.Xml;
using Steam4Intermediate.NodeBehavior;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

namespace Steam4Intermediate.Nodes
{
    class CXXMethodNode : LinkBehavior
    {
        public CXXMethodNode(XmlAttributeCollection collection)
            : base(collection)
        {

        }

        public override void EmitCode(Generator generator, int depth, int ident)
        {
            bool genericwrapper = false;
            List<int> maskedparams = new List<int>();

            INode returntype;
            bool constness, pointer;

            string returns_base = base.ResolveType( 0, out returntype, out constness, out pointer );

            Debug.Assert(returns_base != null);

            if ( returns_base == null )
            {
                returns_base = "(null)";
            }

            string returns = returns_base;

            if ( pointer )
            {
                if ((returntype is RecordNode && returntype.GetAttribute("kind") == "class" && returntype.GetName().StartsWith("I") ) ||
                        (returntype is FundamentalTypeNode && returns == "void"))
                {
                    genericwrapper = true;
                    returns = "IntPtr";
                }
            }

            returns = generator.ResolveType( returns, constness, pointer, true, false );

            /*if (returns == "UInt64" || returns == "Int64")
            {
                returnbystack = true;
            }
            */

            List<INode> args = new List<INode>();

            foreach( INode child in children )
            {
                if ( child is ParmVarNode )
                {
                    args.Add( child );
                }
            }

            List<string> arg = new List<string>();
            List<string> arg_native = new List<string>();
            List<string> arg_native_pure = new List<string>();

            arg_native.Add( "IntPtr thisptr" );

            for (int i = 0; i < args.Count; i++)
            {
                INode argtype;
                bool argconst, argpointer;

                string argname = args[i].GetName();

                string argtypes = args[i].ResolveType(0, out argtype, out argconst, out argpointer);

                Debug.Assert(argtypes != null);

                argtypes = generator.ResolveType(argtypes, argconst, argpointer, false, true);

                if ( genericwrapper && argtypes == "string" )
                {
                    maskedparams.Add( i );
                }

                if ( String.IsNullOrEmpty( argname ) )
                {
                    argname = "arg" + i;
                }

                if ( !maskedparams.Contains( i ) )
                    arg.Add( argtypes + " " + argname );
            }

            string methodname = GetName();
            string extra = "";

            if ( genericwrapper )
            {
                returns = "TClass";
                methodname = methodname + "<TClass>";
                extra = " where TClass : class";
            }

            generator.EmitLine( String.Format( "[VTableSlot({0})]", ident ), depth );
            generator.EmitLine( String.Format( "{0} {1}({2}){3};", returns, methodname, String.Join(", ", arg.ToArray() ), extra), depth );
        }


        private string GetArgIdent( List<string> args )
        {
            StringBuilder ident = new StringBuilder();

            foreach( string arg in args )
            {
                //ident.Append( arg.Substring(0, 1).ToUpper() );
        
                ident.Append( arg.Replace("ref", "").Trim().Substring(0, 1).ToUpper() );
            }

            return ident.ToString();
        }

    }
}

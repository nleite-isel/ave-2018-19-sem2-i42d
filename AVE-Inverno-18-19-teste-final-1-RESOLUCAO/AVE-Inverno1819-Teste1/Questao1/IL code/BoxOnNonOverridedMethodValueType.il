
// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly 'BoxOnNonOverridedMethodValueType'
{
  .hash algorithm 0x00008004
  .ver 1:0:6689:29338
}
.module 'BoxOnNonOverridedMethodValueType.exe'
// MVID: {F89896EA-852B-4DCA-AD23-ED4BCEFE9E26}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000003    //  ILONLY 32BITREQUIRED


// =============== CLASS MEMBERS DECLARATION ===================

//
// Struct V
//
.class private sequential ansi sealed beforefieldinit AVEInverno1819Teste1.Questao1.V
       extends [mscorlib]System.ValueType
{
  .pack 0
  .size 1
} // end of class AVEInverno1819Teste1.Questao1.V

.class public auto ansi beforefieldinit AVEInverno1819Teste1.Questao1.Questao1
       extends [mscorlib]System.Object
{
  .method public hidebysig static void  Main() cil managed
  {
    .entrypoint
    // Code size       29 (0x1d)
    .maxstack  1
    .locals init (valuetype AVEInverno1819Teste1.Questao1.V V_0)
    IL_0000:  nop
    IL_0001:  ldloca.s   V_0
    IL_0003:  initobj    AVEInverno1819Teste1.Questao1.V
    
    // A instrucao constrained realiza box se for necessario, i.e., se for um tipo valor 
    // e se invocar um metodo de object nao redefinido no tipo valor
    //
    // IL_0009:  ldloca.s   V_0
    // IL_000b:  constrained. AVEInverno1819Teste1.Questao1.V
    // Unhandled Exception:
    // System.NullReferenceException: Object reference not set to an instance of an object
    // at AVEInverno1819Teste1.Questao1.Questao1.Main () [0x00009]
    
    // Se se fizer apenas ldloca.s   V_0 ou  ldloc.0   nao funciona
    // pois um metodo de object espera um this que e' um objecto no heap
    // (contendo um header)
      
    // Fazendo ldloc.0 + box ja funciona
    ldloc.0   
    // Experimentem colocar a linha do box em comentario
    box AVEInverno1819Teste1.Questao1.V
    
    IL_0011:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0016:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_001b:  nop
    IL_001c:  ret
  } // end of method Questao1::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Questao1::.ctor

} // end of class AVEInverno1819Teste1.Questao1.Questao1
// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************























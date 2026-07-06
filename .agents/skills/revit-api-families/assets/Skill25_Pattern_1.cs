public void VerificarEntorno(Document doc)
{
    if (!doc.IsFamilyDocument)
    {
        throw new InvalidOperationException("Este comando solo puede ejecutarse en el Editor de Familias.");
    }
}

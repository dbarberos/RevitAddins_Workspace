using System;
using System.Collections.Generic;

namespace TransferPlus.Models
{
	// Token: 0x02000027 RID: 39
	public class Nodo
	{
		// Token: 0x0600018B RID: 395 RVA: 0x000146F8 File Offset: 0x000128F8
		public Nodo(string nombrenodo, int _Num)
		{
			this.NombreNodo = nombrenodo;
			this.Categoria = "";
			this.Familia = "";
			this.Tipo = "";
			this.Nombre = "";
			this.Checked = false;
			this.Num = _Num;
			this.profundidad = 0;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0001479C File Offset: 0x0001299C
		public Nodo(string nombrenodo)
		{
			this.NombreNodo = nombrenodo;
			this.Categoria = "";
			this.Familia = "";
			this.Tipo = "";
			this.Nombre = "";
			this.Checked = false;
			this.Num = 0;
			this.profundidad = 0;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600018D RID: 397 RVA: 0x00014840 File Offset: 0x00012A40
		// (set) Token: 0x0600018E RID: 398 RVA: 0x00014848 File Offset: 0x00012A48
		public string NombreNodo
		{
			get
			{
				return this._nombrenodo;
			}
			set
			{
				this._nombrenodo = value;
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00014851 File Offset: 0x00012A51
		public string Descripcion()
		{
			return this.NombreNodo;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00014859 File Offset: 0x00012A59
		public bool Has_childs()
		{
			return this.Nodos.Count + this.Elementos.Count > 0;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00014878 File Offset: 0x00012A78
		public bool Has_Nodos()
		{
			return this.Nodos.Count > 0;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0001488B File Offset: 0x00012A8B
		public bool Has_elemento()
		{
			return this.Elementos.Count > 0;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0001489E File Offset: 0x00012A9E
		public IList<Nodo> childs_nodos()
		{
			return this.Nodos.Values;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000148AC File Offset: 0x00012AAC
		public IList<object> childs()
		{
			IList<object> list = new List<object>();
			foreach (object item in this.Elementos)
			{
				list.Add(item);
			}
			foreach (KeyValuePair<string, Nodo> keyValuePair in this.Nodos)
			{
				list.Add(keyValuePair.Value);
			}
			return list;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00014944 File Offset: 0x00012B44
		public IList<Elemento> childs_vistas()
		{
			return this.Elementos;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0001494C File Offset: 0x00012B4C
		public void set_Vistas(IList<Elemento> Vistas_A_Almacenar)
		{
			foreach (Elemento item in Vistas_A_Almacenar)
			{
				this.Elementos.Add(item);
			}
		}

		// Token: 0x04000141 RID: 321
		public SortedList<string, Nodo> Nodos = new SortedList<string, Nodo>();

		// Token: 0x04000142 RID: 322
		public int rama;

		// Token: 0x04000143 RID: 323
		public IList<Elemento> Elementos = new List<Elemento>();

		// Token: 0x04000144 RID: 324
		public Nodo Padre;

		// Token: 0x04000145 RID: 325
		private string _nombrenodo;

		// Token: 0x04000146 RID: 326
		public string Categoria = "";

		// Token: 0x04000147 RID: 327
		public string Familia = "";

		// Token: 0x04000148 RID: 328
		public string Tipo = "";

		// Token: 0x04000149 RID: 329
		public string Nombre = "";

		// Token: 0x0400014A RID: 330
		public int Num;

		// Token: 0x0400014B RID: 331
		public bool Checked = true;

		// Token: 0x0400014C RID: 332
		public int profundidad;
	}
}

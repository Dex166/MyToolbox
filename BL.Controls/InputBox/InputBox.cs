namespace BL.Controls
{
	public static class InputBox
	{
		public static string ShowDialog(string content="")
		{
			InputBoxWindow msg = new (content);
			msg.ShowDialog();
			return msg.Text;
		}
	}
}

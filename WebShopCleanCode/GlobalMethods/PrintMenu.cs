﻿namespace WebShopCleanCode.GlobalMethods
{
    public class PrintMenu
    {
        List<string> options;
        public PrintMenu(List<string> options)
        {
            this.options = options;
        }
        public void Menu()
        {
            foreach (string option in options)
            {
                Console.WriteLine(option);
            }
        }
    }
}

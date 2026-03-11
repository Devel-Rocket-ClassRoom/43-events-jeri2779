class Button
    {
        public event EventHandler1 Clicked;
        public void OnClick()
        {
            if (Clicked != null)
                Clicked();
        }
    }
    



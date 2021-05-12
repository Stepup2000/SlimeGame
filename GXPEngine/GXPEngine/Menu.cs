using System.Collections.Generic;

namespace GXPEngine
{
    public class Menu : GameObject
    {
        public enum ScrType : int
        {
            MAINMENU,
            CHARSELECT,
            CONTROLS,
            PAUSEMENU
        }

        private List<MenuButton> buttons = new List<MenuButton>();
        private int _menuType;
        private const int X_OFFSET = 394;
        public Menu(int type) : base()
        {
            _menuType = type;
            switch(_menuType)
            {
                case (int)ScrType.MAINMENU:
                default:
                    AddChild(new Sprite("MainScreen.png"));
                    MenuButton button1 = new MenuButton("PlayButton.png", "PlayButtonPressed.png");
                    buttons.Add(button1);
                    AddChild(button1);
                    MenuButton button2 = new MenuButton("SettingsButton.png", "SettingsPressed.png");
                    buttons.Add(button2);
                    AddChild(button2);
                    MenuButton button3 = new MenuButton("ControlsButton.png", "ControlsButtonPressed.png");
                    buttons.Add(button3);
                    AddChild(button3);
                    MenuButton button4 = new MenuButton("ExitButton.png", "ExitButtonPressed.png");
                    buttons.Add(button4);
                    AddChild(button4);

                    for (int i = 0; i < buttons.Count; i++)
                    {
                        buttons[i].SetOrigin(buttons[i].width / 2, buttons[i].height / 2);
                        buttons[i].SetXY(X_OFFSET + i * 411, 600);
                    }

                    button2.x += 25;
                    button4.x -= 45;

                    break;
                case (int)ScrType.CHARSELECT:
                    AddChild(new Sprite("Selection Menu.png"));
                    MenuButton button_back = new MenuButton("BackButton.png", "BackButton_Pressed.png");
                    buttons.Add(button_back);
                    AddChild(button_back);
                    button_back.SetOrigin(button_back.width / 2, button_back.height / 2);
                    button_back.SetXY(100, 70);
                    MenuButton button_load = new MenuButton("Confirmation Button.png", "Confirmation Button_Pressed.png");
                    buttons.Add(button_load);
                    AddChild(button_load);
                    button_load.SetOrigin(button_load.width / 2, button_load.height / 2);
                    button_load.SetXY(960, 960);
                    break;
                case (int)ScrType.CONTROLS:
                    AddChild(new Sprite("ControlsMenu.png"));
                    MenuButton button_back1 = new MenuButton("BackButton.png", "BackButton_Pressed.png");
                    buttons.Add(button_back1);
                    AddChild(button_back1);
                    button_back1.SetOrigin(button_back1.width / 2, button_back1.height / 2);
                    button_back1.SetXY(90, 70);
                    break;
                case (int)ScrType.PAUSEMENU:
                    AddChild(new Sprite("PauseMenu.png"));
                    // todo: add the buttons (functionality should already be up)
                    break;
            }
        }

        private void sprFeedbackOnHover()
        {
            for (int i = buttons.Count; i > 0; i--)
            {
                if (buttons[i - 1].HitTestPoint(Input.mouseX, Input.mouseY))
                {
                    buttons[i - 1].name = buttons[i - 1].highlightString;
                    buttons[i - 1].ReinitSprite();
                }

                else
                {
                    buttons[i - 1].name = buttons[i - 1].mainString;
                    buttons[i - 1].ReinitSprite();
                }
            }
        }

        private void actionsOnClick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (_menuType)
                {
                    case (int)ScrType.MAINMENU:
                    default:
                        if (buttons[0].HitTestPoint(Input.mouseX, Input.mouseY))    // new game
                        {
                            game.AddChild(new Menu((int)ScrType.CHARSELECT));
                            LateDestroy();
                            game.RemoveChild(this);
                        }
                        if (buttons[2].HitTestPoint(Input.mouseX, Input.mouseY))    // controls
                        {
                            game.AddChild(new Menu((int)ScrType.CONTROLS));
                        }
                        if (buttons[3].HitTestPoint(Input.mouseX, Input.mouseY))    // exit
                        {
                            System.Environment.Exit(-1);
                        }
                        break;
                    case (int)ScrType.CHARSELECT:
                        if (buttons[0].HitTestPoint(Input.mouseX, Input.mouseY))    // back
                        {
                            game.AddChild(new Menu((int)ScrType.MAINMENU));
                            LateDestroy();
                            game.RemoveChild(this);
                        }
                        if (buttons[1].HitTestPoint(Input.mouseX, Input.mouseY))    // confirm - load level
                        {
                            (game as MyGame).LoadLevel();
                            LateDestroy();
                            game.RemoveChild(this);
                        }
                        break;
                    case (int)ScrType.CONTROLS:
                        if (buttons[0].HitTestPoint(Input.mouseX, Input.mouseY))    // back
                        {
                            game.AddChild(new Menu((int)ScrType.MAINMENU));
                            LateDestroy();
                            game.RemoveChild(this);
                        }
                        break;
                    case (int)ScrType.PAUSEMENU:
                        if (buttons[0].HitTestPoint(Input.mouseX, Input.mouseY))    // resume
                        {
                            (game as MyGame).paused = false;
                            LateDestroy();
                            game.RemoveChild(this);
                        }
                        if (buttons[1].HitTestPoint(Input.mouseX, Input.mouseY))    // restart
                        {
                            LateDestroy();
                            game.RemoveChild(this);
                            (game as MyGame).world.DestroyLevel();
                            (game as MyGame).LoadLevel();
                        }
                        if (buttons[3].HitTestPoint(Input.mouseX, Input.mouseY))    // controls
                        {
                            game.AddChild(new Menu((int)ScrType.CONTROLS));
                        }
                        if (buttons[4].HitTestPoint(Input.mouseX, Input.mouseY))    // exit
                        {
                            System.Environment.Exit(-1);
                        }
                        break;
                }
            }
        }

        private void Update()
        {
            sprFeedbackOnHover();
            actionsOnClick();
        }
    }
}

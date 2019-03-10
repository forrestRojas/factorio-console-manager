using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp.ConsoleLayout.Headers
{
    public class BoxBuilder
    {
        private readonly char[][] boxChars = 
        {
           new char[] { '─', '━', '═', '╴', '╶', '╸', '╺', '╼', '╾', '╌', '╍', '┄', '┅', '┈', '┉' },
           new char[] { '│', '┃', '║', '╵', '╷', '╹', '╻', '╽', '╿', '╎', '╏', '┆', '┇', '┊', '┋' },
           new char[] { '' }
        };

        /* 
         *  ─	━	│	┃	┄	┅	┆	┇	┈	┉	┊	┋	┌	┍	┎	┏
         *  ┐	┑	┒	┓	└	┕	┖	┗	┘	┙	┚	┛	├	┝	┞	┟
         *  ┠	┡	┢	┣	┤	┥	┦	┧	┨	┩	┪	┫	┬	┭	┮	┯
         *  ┰	┱	┲	┳	┴	┵	┶	┷	┸	┹	┺	┻	┼	┽	┾	┿
         *  ╀	╁	╂	╃	╄	╅	╆	╇	╈	╉	╊	╋	╌	╍	╎	╏
         *  ═	║	╒	╓	╔	╕	╖	╗	╘	╙	╚	╛	╜	╝	╞	╟
         *  ╠	╡	╢	╣	╤	╥	╦	╧	╨	╩	╪	╫	╬	╭	╮	╯
         *  ╰	╱	╲	╳	╴	╵	╶	╷	╸	╹	╺	╻	╼	╽	╾	╿
         */


        /*
         *  ─   │   ┌   ┐   └   ┘   ├   ┤   ┼   ┬   ┴
         *  ━   ┃   ┏   ┓   ┗   ┛   ┣   ┫   ╋   ┳   ┻
         *  ═   ║   ╔   ╗   ╚   ╝   ╠   ╣   ╬   ╦   ╩
         *  ╌   ╎   ┍   ┑   ┕   ┙   ┝   ┥   ╪
         *  ╍   ╏   ┎   ┒   ┖   ┚   ┠   ┨   ╫
         *  ┄   ┆
         *  ┅   ┇
         *  ┈   ┊
         *  ┉   ┋
        */
    }
}

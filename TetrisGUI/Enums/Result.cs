using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisGUI
{
    enum Result
    {
        SUCCESS,
        DOWN_BORDER_STRIKE,
        BORDER_STRIKE,
        HEAP_STRIKE,
        SIDE_HEAP_STRIKE
    }
}

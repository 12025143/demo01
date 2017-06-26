Public Class clsPoint
    Dim _x As Double
    Dim _y As Double
    Dim _z As Double
    Dim _u As Double
    Dim _v As Double
    Dim _w As Double
    Dim _J1F As Double
    Dim _J2F As Double
    Dim _J4F As Double
    Dim _J6F As Double
    Dim _t As Double
    Dim _b1 As Double
    Dim _b2 As Double
    Dim _Alarm1 As Double
    Dim _h As Double
    Dim _d As Double
    Public Property X() As Double
        Get
            Return _x
        End Get
        Set(ByVal value As Double)
            _x = value
        End Set
    End Property
    Public Property Y() As Double
        Get
            Return _y
        End Get
        Set(ByVal value As Double)
            _y = value
        End Set
    End Property
    Public Property Z() As Double
        Get
            Return _z
        End Get
        Set(ByVal value As Double)
            _z = value
        End Set
    End Property
    Public Property U() As Double
        Get
            Return _u
        End Get
        Set(ByVal value As Double)
            _u = value
        End Set
    End Property
    Public Property V() As Double
        Get
            Return _v
        End Get
        Set(ByVal value As Double)
            _v = value
        End Set
    End Property
    Public Property W() As Double
        Get
            Return _w
        End Get
        Set(ByVal value As Double)
            _w = value
        End Set
    End Property
    Public Property J1F() As Double
        Get
            Return _J1F
        End Get
        Set(ByVal value As Double)
            _J1F = value
        End Set
    End Property
    Public Property J2F() As Double
        Get
            Return _J2F
        End Get
        Set(ByVal value As Double)
            _J2F = value
        End Set
    End Property
    Public Property J4F() As Double
        Get
            Return _J4F
        End Get
        Set(ByVal value As Double)
            _J4F = value
        End Set
    End Property
    Public Property J6F() As Double
        Get
            Return _J6F
        End Get
        Set(ByVal value As Double)
            _J6F = value
        End Set
    End Property
    Public Property Tool() As Double
        Get
            Return _t
        End Get
        Set(ByVal value As Double)
            _t = value
        End Set
    End Property
    Public Property B1() As Double
        Get
            Return _b1
        End Get
        Set(ByVal value As Double)
            _b1 = value
        End Set
    End Property
    Public Property B2() As Double
        Get
            Return _b2
        End Get
        Set(ByVal value As Double)
            _b2 = value
        End Set
    End Property
    Public Property Alarm1() As Double
        Get
            Return _Alarm1
        End Get
        Set(ByVal value As Double)
            _Alarm1 = value
        End Set
    End Property
    Public Property Hand() As Double
        Get
            Return _h
        End Get
        Set(ByVal value As Double)
            _h = value
        End Set
    End Property
    Public Property Done() As Double
        Get
            Return _d
        End Get
        Set(ByVal value As Double)
            _d = value
        End Set
    End Property
End Class

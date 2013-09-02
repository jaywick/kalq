
''' <summary>
''' Custom attribute to create a warning when using an experimental method, class or other structure.
''' An experimental item should be avoided for production builds.
''' </summary>
''' <remarks>Using the obsolete annotation is a hack to cause a compiler warning.</remarks>
<Obsolete("Warning this is experimental and not to be used in production builds.")>
Public Class Experimental
    Inherits System.Attribute
End Class
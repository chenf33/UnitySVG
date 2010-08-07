public class uSVGPathSegCurvetoCubicSmoothAbs : uSVGPathSegCurvetoCubic, uISVGDrawableSeg  {
  private float _x  = 0f;
  private float _y  = 0f;
  private float _x2  = 0f;
  private float _y2  = 0f;
  //================================================================================
  public float x {
    get{ return this._x;}
  }
  //-----
  public float y {
    get{ return this._y;}
  }
  //-----
  public float x2 {
    get{ return this._x2;}
  }
  //-----
  public float y2 {
    get{ return this._y2;}
  }
  //================================================================================
  public uSVGPathSegCurvetoCubicSmoothAbs(float x2, float y2, float x, float y)
                    : base(uSVGPathSegTypes.PATHSEG_CURVETO_CUBIC_SMOOTH_ABS) {
    this._x = x;
    this._y = y;
    this._x2 = x2;
    this._y2 = y2;
  }
  //================================================================================
  public override uSVGPoint currentPoint{
    get{
      uSVGPoint _return = new uSVGPoint(this._x, this._y);
      return _return;
    }
  }
  //-----
  public override uSVGPoint controlPoint1{
    get{
      uSVGPoint _return = new uSVGPoint(0f,0f);
      uSVGPathSeg _prevSeg = previousSeg;
      if(_prevSeg != null) {
        uSVGPoint t_currP = previousPoint;
        uSVGPoint t_prevCP2 = ((uSVGPathSegCurvetoCubic)_prevSeg).controlPoint2;
        uSVGPoint t_P = t_currP - t_prevCP2;
        _return = t_currP + t_P;
      }
      return _return;
    }
  }
  //-----
  public override uSVGPoint controlPoint2{
    get{
      return new uSVGPoint(this._x2, this._y2);
    }
  }
  //--------------------------------------------------------------------------------
  //Method: Render
  //--------------------------------------------------------------------------------
  public void Render(uSVGGraphicsPath _graphicsPath) {
    uSVGPoint p, p1, p2;
    p1 = controlPoint1;
    p2 = controlPoint2;
    p = currentPoint;
    _graphicsPath.AddCubicCurveTo(p1, p2, p);
  }
}
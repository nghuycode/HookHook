using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public App app
    {
        get
        {
            return m_app = Assert<App>(m_app);
        }
    }
    private App m_app;

    public T Assert<T>(T p_var) where T : Object
    {
        return p_var == null ? (GameObject.FindObjectOfType<T>()) : p_var;
    }
}

public class Entity<T> : Entity where T : App
{
    new public T app
    {
        get
        {
            return (T)base.app;
        }
    }
}

public class App : Entity
{
    /// <summary>
    /// Fetches the root Model instance.
    /// </summary>
    public Model model { get { return m_model = Assert<Model>(m_model); } }
    private Model m_model;

    /// <summary>
    /// Fetches the root View instance.
    /// </summary>
    public View view { get { return m_view = Assert<View>(m_view); } }
    private View m_view;

    /// <summary>
    /// Fetches the root Controller instance.
    /// </summary>
    public Controller controller { get { return m_controller = Assert<Controller>(m_controller); } }
    private Controller m_controller;
}

public class Application<M, V, C> : App
    where M : Model
    where V : View
    where C : Controller
{
    new public M model;
    new public V view;
    new public C controller;
}
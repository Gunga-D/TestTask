using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] private List<InventoryCategory> _categories = new List<InventoryCategory>();
    [SerializeField] private List<InventoryPage> _matchingPages = new List<InventoryPage>();
    private Dictionary<InventoryCategory, InventoryPage> _matchSections = new Dictionary<InventoryCategory, InventoryPage>();

    private InventoryCategory _selectedCategory;

    private void Awake()
    {
        if(_categories.Count != _matchingPages.Count)
        {
            throw new System.ArgumentException("The number of elements in both lists must be the same.");
        }

        for(int i = 0; i < _categories.Count; i++)
        {
            if (_categories[i].Unlocked)
            {
                _categories[i].Selected += OnSelectCategory;
            }
            else
            {

            }

            _matchSections.Add(_categories[i], _matchingPages[i]);
        }

        _categories.Clear();
        _matchingPages.Clear();

        _selectedCategory = _matchSections.ElementAt(0).Key;
        _selectedCategory.OnClick();
    }

    private void OnSelectCategory(InventoryCategory category)
    {
        if(_selectedCategory != null)
        {
            _matchSections[_selectedCategory].Close();
        }
        _selectedCategory = category;

        _matchSections[category].Open();
    }

    public InventoryMenuItem GetSelectedItem()
    {
        return _matchSections[_selectedCategory].GetSelectedItem();
    }
}

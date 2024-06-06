using System;
using System.Collections.Generic;

public class Network
{
  private List<Tuple<int, int>> list_connected;

  public Network(int element_number)
  {
    if (element_number > 0)
    {
      list_connected = new List<Tuple<int, int>>(element_number);
    }
    else
    {
      throw new ArgumentException("Number of elements cannot be less than 0");
    }
  }

  public void Connect(int link_number_one, int link_number_two)
  {
    if (link_number_one > 0 & link_number_two > 0)
    {
      list_connected.Add(new Tuple<int, int>(link_number_one, link_number_two));
    }
    else
    {
      throw new ArgumentException("Number of elements cannot be less than 0");
    }
  }

  public void Query(int link_number_one, int link_number_two)
  {
    List<int> list_connected_one = new List<int>();
    List<int> list_connected_two = new List<int>();

    if (link_number_one > 0 & link_number_two > 0)
    {
      foreach (Tuple<int, int> connected_numbers in list_connected)
      {

        if ((connected_numbers.Item1 == link_number_one && connected_numbers.Item2 == link_number_two) || (connected_numbers.Item1 == link_number_two && connected_numbers.Item2 == link_number_one))
        {
          Console.WriteLine($"{link_number_one} and {link_number_two} are linked directly");
          return;
        }

        if (connected_numbers.Item1 == link_number_one)
        {
          list_connected_one.Add(connected_numbers.Item2);
        }
        else if (connected_numbers.Item2 == link_number_one)
        {
          list_connected_one.Add(connected_numbers.Item1);
        }
        else if (connected_numbers.Item1 == link_number_two)
        {
          list_connected_two.Add(connected_numbers.Item2);
        }
        else if (connected_numbers.Item2 == link_number_two)
        {
          list_connected_two.Add(connected_numbers.Item1);
        }
      }

      foreach (int number in list_connected_one)
      {
        if (list_connected_two.Contains(number))
        {
          Console.WriteLine($"{link_number_one} and {link_number_two} are linked indirectlya");
          return;
        }
      }

      Console.WriteLine($"{link_number_one} and {link_number_two} are not connected");
    }
    else
    {
      throw new ArgumentException("Number of elements cannot be less than 0");
    }
  }
}
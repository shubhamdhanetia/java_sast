package mypack;
import java.util.List;
import java.util.ArrayList;


@interface ClassPreamble {
   String author();
   String date();
   int currentRevision() default 1;
   String lastModified() default "N/A";
   String lastModifiedBy() default "N/A";
   // Note use of array
   String[] reviewers();
}

@Entity
class OuterClass {
  @Persistent
  int x = 10;
  public static int MONDAY = 0;
  private static final int[] MY_ARRAY = {10, 20, 30, 40, 50};

  class InnerClass {
    int y = 5;

     public int myInnerMethod() {
      return x;
    }

  }
  @Deprecated
  private class InnerClassPrivate {
    int y = 5;
  }
  
  static class InnerClassStatic {
    int y = 5;
  }
}

@ClassPreamble (
   author = "John Doe",
   date = "3/17/2002",
   currentRevision = 6,
   lastModified = "4/12/2004",
   lastModifiedBy = "Jane Doe",
   // Note array notation
   reviewers = {"Alice", "Bob", "Cindy"}
)
public class Java8Tester {

private GreetingService _GreetingService;

public static < E > void printArray( E[] inputArray ) {
      // Display array elements
      for(E element : inputArray) {
         System.out.printf("%s ", element);
      }
      System.out.println();
   }

private static double sum(List<? extends Number> list)  
    { 
        double sum=0.0; 
        for (Number i: list) 
        { 
            sum+=i.doubleValue(); 
        } 
  
        return sum; 
    }

private String _privatefname = "John";
protected String _protectedfname = "John";
int constructorset;
int instancevariable_x = 5;
final int instancefinalvariable_x = 10;

public Java8Tester(){
constructorset = 5;
}

public Java8Tester(int x){
constructorset = x;
}

synchronized void printTable(int n){//synchronized method  
   for(int i=1;i<=5;i++){  
     System.out.println(n*i);  
     try{  
      Thread.sleep(400);  
     }catch(Exception e){System.out.println(e);}  
   }  
  
 }

enum Level {
    LOW,
    MEDIUM,
    HIGH
  }

final static String salutation = "Hello! ";

// This is a comment

 /* This is my first java program.
    * This will print 'Hello World' as the output
    * This is an example of multi-line comments.
 */

  public void fullThrottle() {
    System.out.println("The car is going as fast as it can!");
  }

  static void myMethod() {

  }
  static int myMethod(int x) {
    return 5 + x;
  }

  public static int sum(int k) {
    if (k > 0) {
      return k + sum(k - 1);
    } else {
      return 0;
    }
  }

   public static void main(String args[]) {

   Collection<Integer> collection = new ArrayList<Integer>();
   collection.add(1);
   collection.add(2);
   Integer[] ints = collection.toArray(new Integer[]{});

   Pair<String, Integer> p1 = new OrderedPair<String, Integer>("Even", 8);

   try(FileOutputStream fileOutputStream =newFileOutputStream("/java7-new-features/src/abc.txt")){      
String msg = "Welcome to javaTpoint!";      
byte byteArray[] = msg.getBytes(); //converting string into byte array      
fileOutputStream.write(byteArray);  
System.out.println("Message written to file successfuly!");      
}catch(Exception exception){  
       System.out.println(exception);  
} 


   final double Pi = 3.1415926536;
   Integer[] intArray = { 1, 2, 3, 4, 5 };
   printArray(intArray);
   String suffix_test="java by javatpoint";  
   System.out.println(suffix_test.endsWith("t")); 

        try{

        }catch(Exception ex	){
            throw ex;
        }finally{
        
        }

        try{

        }catch(Exception e){
        
        }

        try {

        }
        finally {

        }

    OuterClass myOuter = new OuterClass();
    OuterClass.InnerClass myInner = myOuter.new InnerClass();
    System.out.println(myInner.y + myOuter.x);

      Java8Tester Java8object = new Java8Tester();

      myMethod();

      Level myVar = Level.MEDIUM; 
      switch(myVar) {
      case LOW:
        System.out.println("Low level");
        break;
      case MEDIUM:
         System.out.println("Medium level");
        break;
      case HIGH:
        System.out.println("High level");
        break;
    }
    int x = 100 + 50;
    x += 5;
    if(x < 5 &&  x < 10)
    {

    }
    if(!(x < 5 && x < 10)){

    }
    while(true){
    break;
    }

    do {
    	break;
       }
    while(true);
   
    for (int i = 0; i < 5; i++) {
	 if (i == 4) {
 	   break;
 	 }		
     }

     for (int i = 0; i < 5; i++) {
	 if (i == 4) {
 	   continue;
 	 }		
     }

    String[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
    cars[0] = "Opel";
    int[][] myNumbers = { {1, 2, 3, 4}, {5, 6, 7} };
    int x = myNumbers[1][2];
    
    String txt = "We are the so-called \"Vikings\" from the north.";
    int myNum = 15;
    int myNum1;
    myNum1 = 15;
    final int myNum2 = 15;
    float myFloatNum = 5.99f;
    char myLetter = 'D';
    boolean myBool = true;
    String firstName = "John ";
    String lastName = "Doe";
    String fullName = firstName + lastName;
    byte mybyte = 100;
    short myshort = 5000;
    long myNumLong = 15000000000L;
    float myNumFloat = 5.75f;
    double myNumDouble = 19.99d;
    boolean isJavaFun = true;
    char myGrade = 'B';
    char a = 65, b = 66, c = 67;
    Integer myIntWrapper = 5;
    Double myDoubleWrapper = 5.99;
    Character myCharWrapper = 'A';

    int myIntCasting = 9;
    double myDoubleCasting = myIntCasting; // Automatic casting: int to double

    double myDoubleCasting1 = 9.78;
    int myIntCasting1 = (int) myDoubleCasting1; // Manual casting: double to int

      GreetingService test;
      GreetingService greetService1 = message -> System.out.println(salutation + message);

      greetService1.sayMessage("Mahesh");

      List names = new ArrayList();
      names.add("Mahesh");
      names.add("Suresh");
      names.forEach(System.out::println);


   }



interface GreetingService {
      void sayMessage(String message);
      public abstract void setName(String name);
   }

}


class MyClass {
  public static void main(String[] args) {
    System.out.println("Default Class");
  }
}

@Entity
final class Vehicle {

  
  protected String brand = "Ford";
  public void honk() {
    System.out.println("Tuut, tuut!");
  }
}

abstract class Person {
  public String fname = "John";
  public abstract void study(); // abstract method 
  public void sleep() {
    System.out.println("Zzz");
  }
}

// Subclass (inherit from Person)
class Student extends Person {
  public void study() {
    System.out.println("Studying all day long");
  }
}

interface FirstInterface {
  public void myMethod(); // interface method
}

interface SecondInterface {
  public void myOtherMethod(); // interface method
}

class DemoClass implements FirstInterface, SecondInterface {
  public void myMethod() {
    System.out.println("Some text..");
  }
  public void myOtherMethod() {
    System.out.println("Some other text...");
  }
}
public class MaximumTest {
   // determines the largest of three Comparable objects
   
   public static <T extends Comparable<T>> T maximum(T x, T y, T z) {
      T max = x;   // assume x is initially the largest
      
      if(y.compareTo(max) > 0) {
         max = y;   // y is the largest so far
      }
      
      if(z.compareTo(max) > 0) {
         max = z;   // z is the largest now                 
      }
      return max;   // returns the largest object   
   }
   
   public static void main(String args[]) {
      System.out.printf("Max of %d, %d and %d is %d\n\n", 
         3, 4, 5, maximum( 3, 4, 5 ));

      System.out.printf("Max of %.1f,%.1f and %.1f is %.1f\n\n",
         6.6, 8.8, 7.7, maximum( 6.6, 8.8, 7.7 ));

      System.out.printf("Max of %s, %s and %s is %s\n","pear",
         "apple", "orange", maximum("pear", "apple", "orange"));
   }
}
public enum Test {
   CAT;
   public static final int C1 = 5;
}
class Employee{
   String data;
   public <T> Employee(T data){
      this.data = data.toString();
   }
   public void dsplay() {
      System.out.println("value: "+this.data);
   }
}
@SomeAnnotation(locations = {"value1", "value2"})
public class GenericConstructor {
   public static void main(String args[]) {
      Employee emp1 = new Employee("Raju");
      emp1.dsplay();
      Employee emp2 = new Employee(12548);
      emp2.dsplay();
   }
}

public class Box<T> {
    // T stands for "Type"
    private T t;

    public void set(T t) { this.t = t; }
    public T get() { return t; }
}

public interface Pair<K, V> {
    public K getKey();
    public V getValue();
}

public class OrderedPair<K, V> implements Pair<K, V> {

    private K key;
    private V value;

    public OrderedPair(K key, V value) {
	this.key = key;
	this.value = value;
    }

    public K getKey()	{ return key; }
    public V getValue() { return value; }
}

public class Util {
    public static <K, V> boolean compare(Pair<K, V> p1, Pair<K, V> p2) {
        return p1.getKey().equals(p2.getKey()) &&
               p1.getValue().equals(p2.getValue());
    }
}
